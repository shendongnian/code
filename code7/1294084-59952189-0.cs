    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net;
    
    using System.Net.Mail;
    
    namespace asp_Semester_Project
    {
        public partial class ContactUs : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                try
                {
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("ishahanbutt789@gmail.com");
                        mailMessage.To.Add("ishahanbutt789@gmail.com");
                        mailMessage.Subject = txtSubject.Text;
                        mailMessage.Body = "<b>Sender Name : </b>" + txtName.Text + "<br/>"
                            + "<b>Sender Email : </b>" + txtEmail.Text + "<br/>"
                            + "<b>Comments : </b>" + txtComments.Text;
                        mailMessage.IsBodyHtml = true;
    
    
                        SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    NetworkCredential nc = new NetworkCredential();
                    nc.UserName = "ishahanbutt789@gmail.com";
                    nc.Password = "******";
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = nc;
                    smtpClient.Port = 587;
                        smtpClient.Send(mailMessage);
                        lblMessage.ForeColor = System.Drawing.Color.Blue;
                        lblMessage.Text = "Thank you for contacting us";
    
                        //txtName.Enabled = false;
                        //txtEmail.Enabled = false;
                        //txtComments.Enabled = false;
                        //txtSubject.Enabled = false;
                        //Button1.Enabled = false;
                }
                catch (Exception ex)
                {
                    // Log the exception information to 
                    // database table or event viewer
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = ex.StackTrace;
                }
            }
        }
    }
