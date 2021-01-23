    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net.Mail;
     
    public partial class SendMail : System.Web.UI.Page
    {
    MailMessage mail = new MailMessage();
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
     
    try
    {
    lblmessage.Text ="";
    mail.To.Add(txtto.Text.Trim());
    mail.From = new MailAddress(txtfrom.Text.Trim());
    mail.Subject = txtsubject.Text.Trim();
    mail.Body = txtbody.Text.Trim();
    mail.IsBodyHtml = true;
    if (uploader.HasFile)
    {
    string filename = uploader.PostedFile.FileName;
    string filepath=Server.MapPath("uploads//"+filename);
    uploader.SaveAs(filepath);
    Attachment attach = new Attachment(filepath);
    attach.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
    mail.Attachments.Add(attach);
    }
     
    SmtpClient client = new SmtpClient();
     
    client.Host = "mail.youdomain.com";
    client.Credentials = new System.Net.NetworkCredential("email username=info@yourdomain.com", "email passowrd");
    client.Send(mail);
    lblmessage.Text = "sent with success";
    }
    catch (Exception ex)
    {
    lblmessage.Text = ex.Message;
    }
    }
     
    }
