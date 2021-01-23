    protected override Task OnActivateAsync()
    {
       if (State == null)
       {
           var initialState = await externalSource.GetSomeState();
           // simplified here but map the values properly onto the actual actor state
           this.State = initialState;
           return base.OnActivateAsync();
       }
    }
