    private int i
    {
        get
        {
            if (Session["i"] == null)
                return 0;
    
            return (int)Session["i"];
        }
        set
        {
            Session["i"] = value;
        }
    }
    
    protected void btnStart_Click(object sender, EventArgs e)
    {
        i++;
    
        lblStart.Text = i.ToString();
    }
