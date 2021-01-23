    SmtpClient SmtpServer = new SmtpClient();
    SmtpServer.Credentials = new System.Net.NetworkCredential("xyz@gmail.com", "password");
    SmtpServer.Port = 587;
    SmtpServer.Host = "smtp.gmail.com";
    SmtpServer.EnableSsl = true;
    mail = new MailMessage();
    String[] addr = TextBox1.Text.Split(',');
    try
    {
       mail.From = new MailAddress("youremail@gmail.com","Your Name", System.Text.Encoding.UTF8);
       Byte i;
       for( i = 0;i< addr.Length; i++)
         mail.To.Add(addr[i]);
       mail.Subject = TextBox3.Text;
       mail.Body = TextBox4.Text;
       if(ListBox1.Items.Count != 0)
       {
          for(i = 0;i<ListBox1.Items.Count;i++)
            mail.Attachments.Add(new Attachment(ListBox1.Items[i].ToString()));
       }
       SmtpServer.Send(mail);
    }
    catch (Exception ex)
    {
       MessageBox.Show("Error" +ex.ToString());
    }
