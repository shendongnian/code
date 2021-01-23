            // Must have a name
            var e = new Expression();
            e.Add(new IsNotNullOrEmpty<string>(GetName));
            Validator.AddRule(new RuleSet(e, null, ShowMissingNameError,
                FailureBehaviour.Terminate, ValidationLevel.Fatal));
