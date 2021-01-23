    public class OuterGrain : Grain, IOuterGrain
    {
        public async Task<string> GetFormattedTime()
        {
            var innerGrain = GrainFactory.GetGrain<IInnerGrain>(1);
            var innerGrainResult = await innerGrain.GetCurrentTime();
            return innerGrainResult.ToString("yy-MM-dd");
        }
    }
    
    public class InnerGrain : Grain, IInnerGrain
    {
        public Task<DateTime> GetCurrentTime()
        {
            return Task.FromResult(DateTime.Now);
        }
    }
