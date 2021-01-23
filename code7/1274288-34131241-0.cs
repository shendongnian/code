    //mail script
               string name = TextBox1.Text;
               string email = TextBox3.Text;
               string feedback = TextBox5.Text;
               System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
               message.To.Add("info@globalestcon.com");
               message.Subject = "Email from website";
               message.From = new System.Net.Mail.MailAddress(email);
               message.Body = feedback;
               System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
               smtp.Send(message);
               TextBox1.Text = "";
               TextBox2.Text = "";
               Response.Write("<script>alert('Form Submitted');</script>");
