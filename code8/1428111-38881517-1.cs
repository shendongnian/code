    using System;
    using System.Collections.Generic;
    using Csla.Rules;
    
    public class CustomBusinessRule : BusinessRule
            {
            public OnlyOneOutPutLocationBusinessRule(Csla.Core.IPropertyInfo primaryProperty) : base(primaryProperty)
                {
                InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
                }
            protected override void Execute(RuleContext context)
                {
                Example target = (Example)context.Target;
                if (!string.IsNullOrEmpty(ReadProperty(target, Example.A).ToString()) && !String.IsNullOrEmpty(ReadProperty(target, Example.B).ToString()))
                    {
                    context.AddErrorResult("At least on property has to be null !");
    
                    }
                }
            }
