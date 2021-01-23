    [Serializable]
    [CollectionDataContract]
    [KnownType(typeof(RuleBase))]
    [KnownType(typeof(RuleSet))]
    public class GenericRuleCollection : ObservableCollection<IRule>
    {
        //...
    }
