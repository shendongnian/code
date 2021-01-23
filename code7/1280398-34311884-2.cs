    protected void Page_Load(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn.ID = "MyId";
        btn.Click += MyEvent;
        HtmlButton b = new HtmlButton();//if you don't want system.web.ui.Button
        b.ServerClick += MyEvent;
        tabellaDownload.Controls.Add(b);
        tabellaDownload.Controls.Add(btn);
    }
    protected void MyEvent(object sender, EventArgs e)
    {
    }
