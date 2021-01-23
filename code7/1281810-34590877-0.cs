    // Process Push Notification payload here.
                    
                    string message = "";
    
                    try
                    {
    
                        var payload = args.Payload;
                        object aps;
                        if (payload.TryGetValue("aps", out aps))
                        {
                            string payloadStr = "";
    
                            try
                            {
                                payloadStr = aps.ToString();
                            }
                            catch (Exception e)
                            {
                            }
    
                            try
                            {
                                var match = Regex.Match(payloadStr, @"alert = (.*);\n");
                                if (match.Success)
                                {
                                    string alertText = match.Groups[1].Value;
                                    message = alertText;
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        message = "payload crash";
                    }
    
                    if (string.IsNullOrEmpty(message))
                        message = "";
    
                    UILocalNotification notification = new UILocalNotification();
                    //NSDate.FromTimeIntervalSinceNow(15);
                    notification.FireDate = NSDate.FromTimeIntervalSinceNow(5);
                    //notification.AlertTitle = "Alert Title"; // required for Apple Watch notifications
                    notification.AlertAction = "Message";
                    notification.AlertBody = message;
                    notification.SoundName = UILocalNotification.DefaultSoundName;
                    UIApplication.SharedApplication.ScheduleLocalNotification(notification);
