    protected override void UpdateReferences(
          Exhibition model, 
          Model.EventManagement.Exhibition entity)
    {
        foreach (var market in model.Markets)
        {
            var marketEntity = Context.Markets.Single(m => m.Id == market.Id);
            entity.Markets.Add(marketEntity);
        }
    }
