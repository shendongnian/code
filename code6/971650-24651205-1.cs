                static void service_Feedback(object sender, Feedback feedback)
                {
                 Log.AddErrorLog(string.Format("Feedback - Timestamp: {0} - DeviceId: {1}", feedback.Timestamp, feedback.DeviceToken));
                 //DeviceToken retrive over here
                }
                static void service_Error(object sender, Exception ex)
                {
                   
                 Log.AddErrorLog(string.Format("Error: {0}", ex.Message));
                 //Error Message if failed
                } 
