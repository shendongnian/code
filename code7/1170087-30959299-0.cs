    protected void Button2_Click(object sender, EventArgs e)
    {
      try
      {
        string email = TextBox1.Text;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=regester;Integrated Security=True");
        string command = "select id,password,email from reg ";
        SqlCommand sqlcmd = new SqlCommand(command, con);
        //sqlcmd.Parameters["@Email"].Value = email;
        //sqlcmd.Parameters.Add("@Email", email);
        con.Open();
        if (con.State == ConnectionState.Open)
        {
            SqlDataReader dtr = sqlcmd.ExecuteReader();
            while (dtr.Read())
            {
                if (dtr[2].ToString().Equals(TextBox1.Text))
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(dtr[2].ToString());
                    mail.From = new MailAddress("mian722@hotmail.com");
                    mail.Subject = "Your userId and Password";
                    mail.Body = "Your<br/> UserId:<b>" + dtr[0].ToString() + "</b><br/>" + "Password:<b>" + dtr[1].ToString() + "</b>";
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("your id", "your password");
                    smtp.EnableSsl = true;
                    //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.EnableSsl = true;
                    //smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true; //Gmail works on Server Secured Layer
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (SmtpException ex)
                    {
                        string javaScript = "<script language=JavaScript>\n" + "alert('SMTP mail exception: " + Microsoft.Security.Application.Encoder.HTMLEncode(ex.Message) + "');\n" + "</script>";
                        RegisterStartupScript("xyz", javaScript);
                        // add logging here
                        break;
                    }  
                    catch (Exception ex)
                    {
                        string javaScript = "<script language=JavaScript>\n" + "alert('A general exception sending mail: " + Microsoft.Security.Application.Encoder.HTMLEncode(ex.Message) + "');\n" + "</script>";
                        RegisterStartupScript("xyz", javaScript);
                        // add logging here
                        break;
                    }  
                    Label1.Text = "check your mailbox for user iD and Password";
                    string javaScript = "<script language=JavaScript>\n" + "alert('User Id and password send to Your mail box');\n" + "</script>";
                    RegisterStartupScript("xyz", javaScript);
                    break;
                }
                else
                {
                    Label1.Text = "Email Id not valid";
                }
            }
          }
        }
      } catch(SqlException sqlexcept)
        {
             string javaScript = "<script language=JavaScript>\n" + "alert('SQL exception: '" + Microsoft.Security.Application.Encoder.HTMLEncode(sqlexcept.Message) ");\n" + "</script>";
              RegisterStartupScript("xyz", javaScript);
              // add logging here
        }
      } catch(Exception except)
        {
             string javaScript = "<script language=JavaScript>\n" + "alert('General mail creation exception: '" + Microsoft.Security.Application.Encoder.HTMLEncode(except.Message) ");\n" + "</script>";
              RegisterStartupScript("xyz", javaScript);
              // add logging here
        }
    }    
