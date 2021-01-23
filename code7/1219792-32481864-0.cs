    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Net.Mail;
    
    public partial class displayRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          string strConn = "my connection string";
          string strSQL = "select * from EmailTable where Sent = 0";
          SqlConnection objConnection = new SqlConnection(strConn);
          SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
          objConnection.Open();
          SqlDataReader objReader = objCommand.ExecuteReader();
          while (objReader.Read())
          {
    
            MailMessage myMessage = new MailMessage();
            myMessage.IsBodyHtml = true;
            myMessage.Subject = "Test Message for " + (objReader.GetValue(1)) + " " + (objReader.GetValue(2));
            myMessage.Body = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8' /> <title>Untitled Document</title> <style type='text/css'> body p { 	font-family: Verdana, Geneva, sans-serif; } body p { 	font-size: small; } </style> </head>  <body> <p>Hello " + (objReader.GetValue(1)) + "</p> <p>This is a test email which will be sent to your email address: " + (objReader.GetValue(3)) + " when the system is live.</p> <p>Thanks.</p> </body> </html>";
            myMessage.From = new MailAddress("senderaddress@mydomain.com", "Sender Name");
            myMessage.To.Add(new MailAddress((objReader.GetString(3)), (objReader.GetString(2))));
    
            SmtpClient mySmtpClient = new SmtpClient();
            mySmtpClient.Send(myMessage);
    
            Response.Write("Email sent to: " + (objReader.GetValue(3)) + "<br>");
    
            // Update the table, assuming ID is the first column in the table.
            // This is for demonstration only and it is not the most efficient way
            // of doing this because a new command is created each time. 
            // The correct way would be to move the command and parameters creation
            // outside the loop and just update the parameter values inside the loop.
            string strConn2 = "my connection string";
            SqlConnection objConnection2 = new SqlConnection(strConn2);
            SqlCommand UpdateCommand = new SqlCommand("UPDATE EmailTable SET Sent = 1, DateSent = @dtSent WHERE id = @thisId", objConnection2);
            objConnection2.Open();
            UpdateCommand.Parameters.AddWithValue("@dtSent", DateTime.Now);
            UpdateCommand.Parameters.AddWithValue("@thisId", objReader.GetValue(0));
            UpdateCommand.ExecuteNonQuery();
            objConnection2.Close();
          }
          objReader.Close();
          objConnection.Close();
        }
    
    }
