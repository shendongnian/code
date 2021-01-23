	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace WebBrowserTesting
	{
		public partial class Form1 : Form
		{
			//siteID
			string[] siteID =
			{
				"http://www.somesite.com/3jhurjkrtukty",
				"http://www.somesite.com/dfb87uhs89h7df9g",
				"http://www.somesite.com/mfg5t456rj"
			};
			//Event counters
			int K1 = 0;
			int K2 = 0;
			int K3 = 0;
			public Form1()
			{
				InitializeComponent();
			}
			private void button1_Click(object sender, EventArgs e)
			{
				runProgram();
			}
			void runProgram()
			{
				for(int k = 0; k < siteID.Length; k++)
				{
					WebBrowser wb1 = new WebBrowser();
					Uri url1 = new Uri(siteID[k]);
					wb1.DocumentCompleted += wb_DocumentCompleted;
					wb1.Navigate(url1);
				}
			}
			void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
			{
				WebBrowser inner = sender as WebBrowser;
				int counter = updateCounter(inner.Url.ToString());
				if (K1/3 == 4 || K2/3 == 4 || K3/3 == 4) //-------- Mysterious bug
				{
					//In my case the page isn't loaded until the fourth event
					//Here the page is fully loaded. Starting a new thread
					Crawler page = new Crawler();
					Thread oThread = new Thread(() => page.scraper(inner));
					oThread.Start();
				}
			}
			//Page isn't loaded until the DocumentCompleted Event has fired 4 times.
			int updateCounter(string kid)
			{
				int num = 99;
				for (int k = 0; k < siteID.Length; k++)
				{
					if(String.Compare(kid, siteID[0]) == 0)
					{
						K1 = K1 + 1;
						num = K1;
					}
					else if (String.Compare(kid, siteID[1]) == 0)
					{
						K2 = K2 + 1;
						num = K2;
					}
					else if (String.Compare(kid, siteID[2]) == 0)
					{
						K3 = K3 + 1;
						num = K3;
					}
				}
				return num;
			}
		}
		public class Crawler
		{
			public void scraper(WebBrowser inn)
			{
				int life = 0;
				
				//Primitive loop for testing purposes
				while (life < 1000)
				{
					if (life % 10 == 0 && life > 1)
					{
						Thread.Sleep(2000);
						inn.Invoke(new Action(() => {
							inn.Document.ExecCommand("SelectAll", false, null);
							inn.Document.ExecCommand("Copy", false, null);
							string content = Clipboard.GetText();
							Console.WriteLine("Content : " + content);
							//write content to file
						}));
					}
					life = life + 1;
				}
			}
		}
	}
