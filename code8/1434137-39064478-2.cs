    public void PostAutomaticRule(dynamic automaticRuleObject, string ruleType)
    {
        switch (ruleType)
        {
            case "Increase_budget":
                var increasedBudgetRule = ConvertToAutomaticRule<IncreaseBudgetRule>(automaticRuleObject);
                break;
        }
    }
    private T ConvertToAutomaticRule<T>(dynamic ruleObject)
    {
        var serializer = new JavaScriptSerializer();
        var json = serializer.Serialize(ruleObject);
        return serializer.Deserialize<T>(json);
    }
