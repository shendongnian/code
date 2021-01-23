    class gridRecord : Validateit
    {
        //.. snip
       public override void Validate()
       {
            this.Quantity.Validate();
            this.Title.Validate();
            this.Pages.Validate();
       }
    }
