    protected int NumberOfControls
    {
        get{return (int)ViewState["NumControls"];}
        set{ViewState["NumControls"] = value;}
    }
    private void addSomeControl()
    {
        TextBox tx = new TextBox();
        tx.ID = "ControlID_" + NumberOfControls.ToString();
        Page.Controls.Add(tx);
        this.NumberOfControls++;
    }
