    using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using Outlook = Microsoft.Office.Interop.Outlook;
	
	namespace testMailEmailUser
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
	
			private void button1_Click(object sender, EventArgs e)
			{
				Outlook.Application application = new Outlook.Application();
				Outlook.AddressEntry mailSender = null;
	
				Outlook.Accounts accounts = application.Session.Accounts;
	
				foreach (Outlook.Account account in accounts)
				{
					mailSender = account.CurrentUser.AddressEntry;
				}
	
				Outlook.MailItem mail =
					application.CreateItem(
					Outlook.OlItemType.olMailItem)
					as Outlook.MailItem;
	
				if (mailSender != null)
				{
					mail.To = "someone@example.com; another@example.com";
					mail.Subject = "Some Subject Matter";
					mail.Body = "Some Body Text";
					mail.Sender = mailSender;
					mail.Display(false);
				}
			}
	
		}
	}
