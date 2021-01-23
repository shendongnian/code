    ProcessStartInfo info = new ProcessStartInfo();
    
    string arguments = String.Format(@"""{0}"" ""{1}""", 
        message.Subject.Replace(@"""", @""""""), 
        message.Body.Replace(@"""", @""""""));
    info.FileName = MAILER_FILEPATH;
    info.Arguments = arguments;
    
    Process.Start(info);
