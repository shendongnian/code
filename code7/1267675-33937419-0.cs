     public class ExampleGrain : Orleans.Grain, IExampleGrain
     {
       public override Task OnActivateAsync()
       {
            // set initial state for grain
            return base.OnActivateAsync();
        }
     ...
