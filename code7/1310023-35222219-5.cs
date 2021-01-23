    protected void Page_Load(object sender, EventArgs e)
    {
        var master = this.Master as Master1;
        if (master != null)
        {
            master.MeaningfulNameForLabelText = "Hello";
        }
    }
