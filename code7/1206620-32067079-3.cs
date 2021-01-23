     protected void Titletxt_TextChanged(object sender, EventArgs e)
    {
    NewsTitlePreview.InnerText = Titletxt.Text;
    UpdatePanel1.Update();
    }
    protected void Contenttxt_TextChanged(object sender, EventArgs e)
    {
    NewsContentPreview.InnerText = Contenttxt.Text;
    UpdatePanel1.Update();
    }
