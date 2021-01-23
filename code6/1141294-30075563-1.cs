    var message = new PremiumAdjustmentFinalisedEvent
    {
        Amount = AdjustmentAmount,
        PolicyNumber = PolicyNumber,
        FinalisedOn = LastModifiedOn
    };    
    Bus.Publish<IPremiumAdjustmentFinalised>(message);
