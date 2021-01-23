    List<CodeItemsRule> _CodeItemRules = new List<CodeItemsRule>()
    {
        new CodeItemsRule()
        {
            CodeID="00009",
            ItemID="D1",
            RuleID=2
        },new CodeItemsRule()
        {
            CodeID="00009",
            ItemID="D2",
            RuleID=2
        },new CodeItemsRule()
        {
            CodeID="00009",
            ItemID="D3",
            RuleID=1
        },new CodeItemsRule()
        {
            CodeID="00008",
            ItemID="D1",
            RuleID=3
        },new CodeItemsRule()
        {
            CodeID="00007",
            ItemID="D3",
            RuleID=1
        },new CodeItemsRule()
        {
            CodeID="00007",
            ItemID="D4",
            RuleID=1
        },new CodeItemsRule()
        {
            CodeID="00010",
            ItemID="D3",
            RuleID=2
        },new CodeItemsRule()
        {
            CodeID="00010",
            ItemID="D1",
            RuleID=1
        },new CodeItemsRule()
        {
            CodeID="00010",
            ItemID="D2",
            RuleID=1
        }
    };
    var pivotTable = _CodeItemRules.ToPivotTable(
        item => item.ItemID,
        item => item.CodeID,
        items => items.Any() ? items.Sum(x => x.RuleID) : 0);
