    private void BtnSend_Click(object sender, EventArgs e)
        {
        
            try
            {
                pbLoad.Visible = true;
    
                Thread t=New Thread(sendemail);
                t.start();
    
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        public void sendemail()
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                  "myID@gmail.com", "mypassword");
                MailMessage msg = new MailMessage();
                msg.To.Add(txt_to.Text);
                msg.From = new MailAddress("myID@gmail.com");
                msg.Subject = txt_sub.Text;
                msg.Body = txt_msg.Text;
        
                //  Attachment data = new Attachment(txt_attach.Text);
                //     msg.Attachments.Add(data);
                // System.Threading.Thread.Sleep(2000);
                client.Send(msg);
        
               this.Invoke(new MethodInvoker(Finished))
        
            }
        }
    
    Private Void Finished() 
    
    {
    
     pbLoad.Visible = false;
     MessageBox.Show("Mail send");
    
    }
