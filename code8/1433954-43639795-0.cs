    StackTrace st = new StackTrace(true);
    StackFrame sf = st.GetFrame(1);
    //build your message
    string newMessage = string.Format("{0} at {1} in {2}:line {3}", msg, sf.GetMethod().ToString(), sf.GetFileName(), sf.GetFileLineNumber());
    if (ApplicationConfiguration.IsLocal()) 
    {
      _logger.Info(newMessage);
    } 
    else
    {
      _logger.Debug(newMessage);
    }
