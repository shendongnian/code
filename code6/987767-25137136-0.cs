    public void dispatchEmail(string activationCode, string username, string emailAddress)
    {
      try
      {
          this.sendEmail(activationCode, username, emailAddress);
      }
      catch (Exception e) // Note: This is considered bad practice, might want to check for specific exceptions
      {
       lblError.Text = "error message: " + e.ToString();
      }
    }
