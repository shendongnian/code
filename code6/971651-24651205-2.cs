    public string CheckFeedBack()
            {
                
                //Variables you may need to edit:
                //---------------------------------
                //Log.AddErrorLog("Start");
                //True if you are using sandbox certificate, or false if using production
                bool sandbox = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["sandbox"].ToString());
    
                //Put your PKCS12 .p12 or .pfx filename here.
                // Assumes it is in the same directory as your app
                string p12File = System.Configuration.ConfigurationManager.AppSettings["p12File"].ToString();
    
                //This is the password that you protected your p12File 
                //  If you did not use a password, set it as null or an empty string
                string p12FilePassword = System.Configuration.ConfigurationManager.AppSettings["p12FilePassword"].ToString();
    
    
                //Actual Code starts below:
                //--------------------------------
    
                //Get the filename assuming the file is in the same directory as this app
                string p12Filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, p12File);
                //errorLog.AddErrorLog(p12Filename);
                //Create the feedback service consumer
                FeedbackService service = new FeedbackService(sandbox, p12Filename, p12FilePassword);
    
                //Wireup the events
                service.Error += new FeedbackService.OnError(service_Error);
                service.Feedback += new FeedbackService.OnFeedback(service_Feedback);
    
                //Run it.  This actually connects and receives the feedback
                // the Feedback event will fire for each feedback object
                // received from the server
                service.Run();
                Log.AddErrorLog("Done.");
                Log.AddErrorLog("Cleaning up...");
    
                //Clean up
                service.Dispose();
    
                return "Checked database table log..";
            } 
            
