    public void logError(string errorString)
    {
         try
         {
             // Takes unknown errors and logs them to the log file 
             string user = HttpContext.Current.User.Identity.Name.ToString();
             string FileLine = user + ", " + DateTime.Now.ToString() + ", " + errorString;
             string filename = HttpContext.Current.Server.MapPath("../Log/error_log.txt");
    
             using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, true))
             {
                 file.WriteLine(FileLine);
                 file.WriteLine("---------------------------------------");
             }
         }
         catch (Exception ex)
         {
            // send email, or another notification 
         }
    
    }
