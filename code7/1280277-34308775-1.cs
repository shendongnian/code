    private void Form1_Load ( object sender, EventArgs e )
    {
        int inputNumber = 5;
        geckowebbrouser = new List<Skybound.Gecko.GeckoWebBrowser>();
        for ( int i = 1; i <= inputNumber; i++ )
        {
            int j = 1;
            String wbname = "br" + i;
            var gw = new Button();
            gw.Width = 200;
            gw.Height = 200;
            gw.Name = wbname; 
            gw.Navigate("http://192.168.1.162:8080");
            geckowebbrouser.Add(gw);
            flowLayoutPanel1.Controls.Add(gw);
        }
    }
