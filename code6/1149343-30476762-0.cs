      using System;
      using System.Configuration;
      using System.Text.RegularExpressions;
        using System.Windows.Forms;
      using Facebook;
      using System.Net;
       using System.Drawing;
      using System.Drawing.Drawing2D;
       using System.Drawing.Imaging;
       using System.IO;
       public Bitmap GenerateScreenshot(string url)
        {
            // This method gets a screenshot of the webpage
            // rendered at its full size (height and width)
            return GenerateScreenshot(url, -1, -1);
        }
        public Bitmap GenerateScreenshot(string url, int width, int height)
        {
            // Load the webpage into a WebBrowser control
            WebBrowser wb = new WebBrowser();
            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(url);
            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            // Set the size of the WebBrowser control
            wb.Width = width;
            wb.Height = height;
            if (width == -1)
            {
                // Take Screenshot of the web pages full width
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
            }
            if (height == -1)
            {
                // Take Screenshot of the web pages full height
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }
            // Get a Bitmap representation of the webpage as it's rendered in the WebBrowser control
            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();
            return bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string pc = textBox1.Text;
            Bitmap thumbnail = GenerateScreenshot(textBox1.Text, 1024, 598);
            thumbnail = GenerateScreenshot(pc);
            // Display Thumbnail in PictureBox control
            pictureBox1.Image = thumbnail;
           
        }
