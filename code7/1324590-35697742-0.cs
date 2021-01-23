    public void Panel1_Click(object sender, EventArgs e)
    {
        //Do whatever you need to do
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        //Do anything you need to do first
        Panel1_Click(Panel1, EventArgs.Empty);
    }
