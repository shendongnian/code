    public void SetMessage(InfoMessages message)
    {
        switch (message)
        {
           case InfoMessages.Error1: this.Message = "Error message for Error1"; break;
           case InfoMessages.Error2: this.Message = "Error message for Error2"; break;
           // ...
        }
    } 
