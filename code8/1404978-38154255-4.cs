    var card = new CardRule()
    {
        Description = "Cause 20 damage, then causes burn status.",
        Rules = ActionRules.Damage(20).WithStatus(Status.Burn);
    };
    
    card.PerformAction(target);
            
