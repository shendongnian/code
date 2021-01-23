    using System.IO;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    protected void Capture(object sender, EventArgs e)
    {
        string url = txtUrl.Text.Trim();
        Thread thread = new Thread(delegate()
        {
            using (WebBrowser browser = new WebBrowser())
            {
                browser.ScrollBarsEnabled = false;
                browser.AllowNavigation = true;
                browser.Navigate(url);
                browser.Width = 1024;
                browser.Height = 768;
                browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
    }
     
    private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser browser = sender as WebBrowser;
        using (Bitmap bitmap = new Bitmap(browser.Width, browser.Height))
        {
            browser.DrawToBitmap(bitmap, new Rectangle(0, 0, browser.Width, browser.Height));
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bytes = stream.ToArray();
                imgScreenShot.Visible = true;
                imgScreenShot.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(bytes);
            }
        }
    }
