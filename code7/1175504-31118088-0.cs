     private void Saat10()
     {
        DataTable dt=verileri_cek();
        if (dt.Rows.Count > 0)
        {
            SmtpClient client = new SmtpClient();
            MailMessage mesaj = new MailMessage();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               mesaj = new MailMessage();
               // all other code
            }
        }
      }
