    c.Bound(m => m.Transaction).Title().ClientTemplate("#=TransactionStateFormat(data)#");
    public enum TransactionState: int 
    {
        Applied = 0,
        OptOut=1,
        Undefined=2
    }
