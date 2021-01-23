    private void Form1_Load ( object sender, EventArgs e )
    {
        int inputNumber = 5;
        geckowebbrouser = new List<Skybound.Gecko.GeckoWebBrowser>();
        for ( int i = 1; i <= inputNumber; i++ )
        {
            int j = 1;
            String wbname = "br" + i;
            var gw = new Skybound.Gecko.GeckoWebBrowser();
            gw.Width = 300;
            gw.Height = 300;
            gw.Name = wbname;
            geckowebbrouser.Add(gw);
            flowLayoutPanel1.Controls.Add(gw);
            gw.Navigate("http://www.google.com");
        }
    }
