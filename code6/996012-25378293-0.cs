    protected override void OnLoad(EventArgs e)
    {
         base.OnLoad(e);
         if (this.Owner != null)
         {
             this.Location = .... // offset this.Owner.Location
         }
    }
