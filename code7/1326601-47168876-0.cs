    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Net;
    using System.Threading;
    
    namespace kek
    {
        public partial class Form1 : Form
        {
            [DllImport("wininet.dll", SetLastError = true)]
            public static extern bool InternetGetCookieEx(string url, string cookieName, StringBuilder cookieData, ref int size, Int32 dwFlags, IntPtr lpReserved);
    
            private Uri Uri = new Uri("http://www.my-cloudflare-protected-website.com");
            private const Int32 InternetCookieHttponly = 0x2000;
            private const Int32 ERROR_INSUFFICIENT_BUFFER = 0x7A;
    
            public Form1()
            {
                InitializeComponent();
    
                webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
    
                webBrowser1.Navigate(Uri, null, null, "User-Agent: kappaxdkappa\r\n"); //user-agent needs to be set another way if that doesnt work
            }
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                int waitTime = 0;
    
                if(webBrowser1.DocumentTitle.Contains("We are under attack")) //check what string identifies the unique cloudflare captcha page and put it here
                {
                    waitTime = 6000;
                }
    
                Task.Run(async () =>
                {
                    await Task.Delay(waitTime); //cookie can be saved right away, but the waiting period might not have passed yet
                    
                    String cloudflareCookie = GetCookie(Uri, "cf_clearance");
    
                    if (!String.IsNullOrEmpty(cloudflareCookie))
                    {
                        System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\CFcookie.blob"); //save to %appdata%\MyProgram\Cookies\clearence.blob
                        file.Write(cloudflareCookie);
                        file.Close();
                    }
                });
            }
    
            String GetCookie(Uri uri, String cookieName)
            {
                int datasize = 0;
                StringBuilder cookieData = new StringBuilder(datasize);
    
                InternetGetCookieEx(uri.ToString(), cookieName, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero);
    
                if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER && datasize > 0)
                {
                    cookieData = new StringBuilder(datasize);
                    if (InternetGetCookieEx(uri.ToString(), cookieName, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero))
                    {
                        if (cookieData.Length > 0)
                        {
                            CookieContainer container = new CookieContainer();
                            container.SetCookies(uri, cookieData.ToString());
    
                            return container.GetCookieHeader(uri);
                        }
                    }
                }
    
                return String.Empty;
            }
        }
    }
