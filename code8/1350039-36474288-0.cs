    public class OuterGrain : Grain, IOuterGrain
    {
        public async Task<string> GetFormattedTimeAsync()
        {
            var innerGrain = GrainFactory.GetGrain<IInnerGrain>(1);
            var innerGrainResult = await innerGrain.GetCurrentTimeAsync();
            return innerGrainResult.ToString("yy-MM-dd");
        }
    }
    
    public class InnerGrain : Grain, IInnerGrain
    {
        public Task<DateTime> GetCurrentTimeAsync()
        {
            return Task.FromResult(DateTime.Now);
        }
    }
