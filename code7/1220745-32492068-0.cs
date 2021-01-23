    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.IO;
    using System.Net.NetworkInformation;
    using System.Net.Security;
    using System.Net.Sockets;
     
    namespace mail
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
     
            }
     
            protected void Button1_Click(object sender, EventArgs e)
            {
     
                Imap client = new Imap();
                // connect to server
    
                client.Connect("imap.gmail.com", 993, SslMode.Implicit);
     
                // authenticate
                client.Login("username", "password");
     
                // select folder
                client.SelectFolder("Inbox");
     
                int NoOfEmailsPerPage = 10;
                int totalEmails = client.CurrentFolder.TotalMessageCount;
                // get message list - envelope headers
                ImapMessageCollection messages = client.GetMessageList(ImapListFields.Envelope);
     
                // display info about each message
              
               
                foreach (ImapMessageInfo message in messages)
                {
                    
                    TableCell noCell = new TableCell();
                    
                    noCell.CssClass = "emails-table-cell";
     
                    noCell.Text = Convert.ToString(message.To);
                    TableCell fromCell = new TableCell();
                    fromCell.CssClass = "emails-table-cell";
                    fromCell.Text = Convert.ToString(message.From);
                    TableCell subjectCell = new TableCell();
                    subjectCell.CssClass = "emails-table-cell";
                    subjectCell.Style["width"] = "300px";
                    subjectCell.Text = Convert.ToString(message.Subject);
                    TableCell dateCell = new TableCell();
                    dateCell.CssClass = "emails-table-cell";
                    if (message.Date.OriginalTime != DateTime.MinValue)
                        dateCell.Text = message.Date.OriginalTime.ToString();
                    TableRow emailRow = new TableRow();
                    emailRow.Cells.Add(noCell);
                    emailRow.Cells.Add(fromCell);
                    emailRow.Cells.Add(subjectCell);
                    emailRow.Cells.Add(dateCell);
                    EmailsTable.Rows.AddAt(2 + 0, emailRow);
                    
                }
                int totalPages;
                int mod = totalEmails % NoOfEmailsPerPage;
                if (mod == 0)
                    totalPages = totalEmails / NoOfEmailsPerPage;
                else
                    totalPages = ((totalEmails - mod) / NoOfEmailsPerPage) + 1;
     
              
     
            }
        }
    }
