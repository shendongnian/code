    using Csla;
    using Csla.Rules;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    protected override void AddBusinessRules()
    {
    BusinessRules.AddRule(new CustomBusinessRule(AProperty));
    BusinessRules.AddRule(new CustomBusinessRule(BProperty));
    BusinessRules.AddRule(new Csla.Rules.CommonRules.Dependency(AProperty, BProperty));
    BusinessRules.AddRule(new Csla.Rules.CommonRules.Dependency(BProperty, AProperty));
    
    }
