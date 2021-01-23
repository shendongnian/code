         private void SendMessage()
            {
                //IOS
                var MainApnsData = new JObject();
                var ApnsData = new JObject();
                var data = new JObject();
               
                MainApnsData.Add("alert", Message.Text.Trim());
                MainApnsData.Add("badge", 1);
                MainApnsData.Add("Sound", "default");
    
                data.Add("aps", MainApnsData);
    
                ApnsData.Add("CalledFromNotify", txtboxID.Text.Trim());
                data.Add("CustomNotify", ApnsData);
    
                //read the .p12 certificate file
                byte[] bdata = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/CertificatesPushNew.p12"));
               
     //create push sharp APNS configuration
                var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox,bdata,"YourPassword");
            
    
                //create a apnService broker
                var apnsBroker = new ApnsServiceBroker(config);
    
                // Wire up events
                apnsBroker.OnNotificationFailed += (notification, aggregateEx) => {
    
                    aggregateEx.Handle(ex => {
    
                        // See what kind of exception it was to further diagnose
                        if (ex is ApnsNotificationException)
                        {
                            var notificationException = (ApnsNotificationException)ex;
    
                            // Deal with the failed notification
                            var apnsNotification = notificationException.Notification;
                            var statusCode = notificationException.ErrorStatusCode;
    
                            Console.WriteLine($"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}");
    
                        }
                        else
                        {
                            // Inner exception might hold more useful information like an ApnsConnectionException			
                            Console.WriteLine($"Apple Notification Failed for some unknown reason : {ex.InnerException}");
                        }
    
                        // Mark it as handled
                        return true;
                    });
                };
    
                apnsBroker.OnNotificationSucceeded += (notification) => {
                    Console.WriteLine("Apple Notification Sent!");
                };
    
                var fbs = new FeedbackService(config);
                fbs.FeedbackReceived += (string deviceToken1, DateTime timestamp) =>
                {
                    //Remove the deviceToken from your database
                    // timestamp is the time the token was reported as expired
                    Console.WriteLine("Feedback received!");
                };
                fbs.Check();
    
                // Start the broker
                apnsBroker.Start();
    
                var deviceToken = "Your device token";
                // Queue a notification to send
                apnsBroker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = deviceToken,
                    Payload= data
                   
     });
    
                // Stop the broker, wait for it to finish   
                // This isn't done after every message, but after you're
                // done with the broker
               apnsBroker.Stop();
            }
