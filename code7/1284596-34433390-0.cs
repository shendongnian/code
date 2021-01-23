    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using mshtml;
    using HtmlAgilityPack;
    
    namespace WebSite_Login_And_Browsing
    {
    	public partial class LogIn : Form
    	{
			public Form1()
			{
				InitializeComponent();
				webBrowser1.ScriptErrorsSuppressed = true;
			}
			
			private void button1_Click(object sender, EventArgs e)
			{
				webBrowser1.DocumentCompleted += process1;
				webBrowser1.Navigate("http://www.tapuz.co.il/Common/SignInPage.aspx?backUrl=http://www.tapuz.co.il/Common/SignIn.aspx@loginDone=1");
			}
			private void process1(object sender, WebBrowserDocumentCompletedEventArgs args)
			{
				webBrowser1.DocumentCompleted -= process1;
				webBrowser1.DocumentCompleted += process2;
				try
				{
					webBrowser1.Document.GetElementById("UserName").InnerText = textBox1.Text.ToString();
					webBrowser1.Document.GetElementById("Password").InnerText = textBox2.Text.ToString();
					webBrowser1.Document.GetElementById("LoginButton").InvokeMember("click");
				}
				catch
				{
					webBrowser1.DocumentCompleted -= process2;
				}
			}
			private void process2(object sender, WebBrowserDocumentCompletedEventArgs args)
			{
				webBrowser1.DocumentCompleted -= process2;
				var items = webBrowser1.Document.GetElementsByTagName("span");
				foreach (HtmlElement item in items)
				{
					if (item.GetAttribute("className") == "validationMsg")
					{
						if (item.InnerText.Contains("שם המשתמש או הסיסמה אינם נכונים"))
						{
							MessageBox.Show("State 1");
							return;
						}
					}
				}
				MessageBox.Show("State 2");
			}
    	}
    }
