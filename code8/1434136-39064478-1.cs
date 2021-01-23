    public void PostAutomaticRule(dynamic automaticRuleObject, string ruleType)
    {
        switch (ruleType)
        {
            case "Increase_budget":
                ConvertToAutomaticRule<IncreaseBudgetRule>(ref automaticRuleObject);
                break;
        }
    }
    private void ConvertToAutomaticRule<T>(ref dynamic ruleObject)
    {
        var serializer = new JavaScriptSerializer();
        var json = serializer.Serialize(ruleObject);
        var c = serializer.Deserialize<T>(json);
    }
