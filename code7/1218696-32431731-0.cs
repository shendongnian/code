    private void timer4_Tick(object sender, EventArgs e)
    {
        for (int a = 0; a < 10; a++)
        {
            var infos = webBrowser1.Document.GetElementsByTagName("img")[a].GetAttribute("src");
            richTextBox1.Text += infos; // the "+=" will add each infos to the textbox
        }
        timer4.Stop();
    }
