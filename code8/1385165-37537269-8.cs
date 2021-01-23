    private int i
    {
        get
        {
            if (Session["i"] == null)
                return 0;
    
            return (int)Session["i"];
            // Instead of 3 lines in the above, you can use this one too as a short form.
            // return (int?) Session["i"] ?? 0;
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
