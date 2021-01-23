    [assembly: AutoDataContractAttribute(AttributePriority = 1,
        AttributeTargetTypes="MyNamespace.Customer")]
    [assembly: AutoDataContractAttribute(AttributeExclude = true,
        AttributeTargetTypes = "MyNamespace.Customer.Excluded.*",
        AttributePriority = 10)]
