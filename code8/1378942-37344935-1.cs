    private static Task<Result> CreateEfTask()
    {
        var t = new Task<List<PricingRule>>(
            () => new global::Entities.Entities().PricingRules.Where(pr => pr.IsEnabled).ToList()).ContinueWith(t=>new Result {PricingRules = t.Result,TimeSpan = DateTime.Now.Subtract(_start)});
        t.Start();
        return t;
    }
