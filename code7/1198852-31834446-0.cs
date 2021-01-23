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
				Outlook.AddressEntry addrEntry = null;
	
				Outlook.Accounts accounts =
					application.Session.Accounts;
	
				
				foreach (Outlook.Account account in accounts)
				{
					addrEntry =
							account.CurrentUser.AddressEntry;
	
				}
	
				Outlook.MailItem mail =
					application.CreateItem(
					Outlook.OlItemType.olMailItem)
					as Outlook.MailItem;
	
				if (addrEntry != null)
				{
					//Set Sender property. 
					mail.Sender = addrEntry;
					mail.Display(false);
				}
			} 
		}
	}
