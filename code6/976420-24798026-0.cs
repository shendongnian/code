    [WebMethod]
    public void UpdateText(string message)
    {
      var master = new SiteMaster();
      master.mySpan.Text = message;
    }
