    public class SpecializedTable<T> 
    {
        private readonly DtaTable table;
        // Just in case anyone really wants this
        public DtaTable Table { get; }
        public SpecializedTable(DtaTable table)
        {
            this.table = table;
        }
        public T this[string row] { get { return (T) (object) table[row]; } }
    }
