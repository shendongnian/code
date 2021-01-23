    public class Table<T> : ..., ITable where T : IRowDef, new()
    {
        IRowDef ITable.GetSth()
        { 
             return (IRowDef)this.GetSthImplInsideTable(); // cast is optional
        }
        public T GetSthImplInsideTable() { /* impl */ }
    }
