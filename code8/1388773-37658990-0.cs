    public static class ContractNames
    {
        public const string Contract = "Contract";
    }
    [Export(ContractNames.Contract, typeof(IInterface))]
    [Export(typeof(IInterface))]
    public class Part : IInterface { /*...*/ }
    ...
        container.GetExportedValue<IInterface>(ContractNames.Contract);
