     private void button1_Click_1(object sender, EventArgs e)
     {
         webBrowser1.Navigate("http://www.naver.com");
         button2.PerformClick();
     }
     private void button2_Click_1(object sender, EventArgs e)
     {
         HtmlWindow wf = webBrowser1.Document.Window.Frames[0];
         string s = wf.Document.Body.OuterHtml;
         MessageBox.Show(s);
     }
