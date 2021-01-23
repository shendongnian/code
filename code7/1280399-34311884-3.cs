    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlButton b = new HtmlButton
        b.ServerClick += MyEvent;
        tabellaDownload.Controls.Add(b);
        /* a table control doesn't accept a btn as child, you need to the exact td cell where insert the button*/
    }
    protected void MyEvent(object sender, EventArgs e)
    {
    }
