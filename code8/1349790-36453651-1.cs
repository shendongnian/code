    protected override void CreateChildControls()
    {
           if(!IsPostBack)
           {
            this.Controls.Add(rdYes);
            this.Controls.Add(rdNo);
           }
     }
