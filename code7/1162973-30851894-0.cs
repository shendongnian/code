     public class StartFinishTimeValidation : Csla.Rules.BusinessRule
        {
            protected override void Execute(Csla.Rules.RuleContext context)
            {
                var target = (PDV)context.Target;
                //var od = (DateTime)ReadProperty(target, PDV.StartDateProperty);
                //var doo = (DateTime)ReadProperty(target, PDV.FinishDateProperty);
                if (target.StartDate > target.FinishDate)
                {
                    context.AddErrorResult("The date is not correct");
                    
                }
                
                
            }
        }
