    public class ExampleGrainState : GrainState
    {
        public bool Initialised { get; set; }
    }
    
    [StorageProvider(ProviderName = "Storage")]
    public class QuadKeyGrain : Orleans.Grain<ExampleGrainState>, IExampleGrain
    {
        public override async Task OnActivateAsync()
        {
            if (!this.State.Initialised)
            {
                // do initialisation 
                this.State.Initialised = true;
                await this.WriteStateAsync();
            }
            await base.OnActivateAsync();
        }
