    void ShowSms(object sender, EventArgs e)
    {
      SmsForm sm; 
      if (Globals.globals.Set.DBConn)
      {
        UnitOfWork uow = new UnitOfWork();
        sm = new SmsForm(uow);                    
      }
      else
        sm = new SmsForm();
      if (sm.Visible)
        sm.Focus();
      else
        sm.Show();
    }
