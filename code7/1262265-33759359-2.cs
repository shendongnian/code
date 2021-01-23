    [Flags]
    public enum ReturnStatus
    {
      NoErrors = 0,
      DBError = 1,
      ThirdPartyError = 2,
      EmailError = 4,
      EmailSend = 8 //This could also be an option, so i just added it here as example, but i'm a bit confused if this is used as a return status or the current state of a task
    }
    ReturnStatus ret = ReturnStatus.DBError | ReturnStatus.EmailError;
    if( ret.HasFlag(ReturnStatus.EmailError) ) {
      //Email failed to send
    }
    if( ret.HasFlag(ReturnStatus.DBError) ) {
      //Db save failed
    }
