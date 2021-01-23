    protected void button_Click(object sender, EventArgs e)
    {
       if(Session["ClickCount"]!=null)
           Session["ClickCount"]=(int)Session["ClickCount"]++;
       else
           Session["ClickCount"]=0;
    }
