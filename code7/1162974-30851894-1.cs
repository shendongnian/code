    protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
            BusinessRules.AddRule(new StartFinishTimeValidation {PrimaryProperty = StartDateProperty });
            BusinessRules.AddRule(new Dependency(StartDate,FinishDate));
            BusinessRules.AddRule(new Dependency(FinishDate, StartDate));
            
        }
