    public string Prop
    {
        get
        {
            return (string)Session["Prop"];
        }
        set
        {
            Session["Prop"] = value;
        }
    }
