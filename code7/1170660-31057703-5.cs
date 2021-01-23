    public class ColumnSchema
    {
        public string ColumnName { get; internal set; }
        public int ColumnPosition { get; internal set; }
        public string Collation { get; internal set; }
        public string TypeName { get; internal set; }
        public short Size { get; internal set; }
        public byte Precision { get; internal set; }
        public byte Scale { get; internal set; }
        internal int _PK { get; set; }
        public bool IsIdentity { get; internal set; }
        public bool IsNullable { get; internal set; }
        public bool IsPrimaryKey
        {
            get { return _PK == 1; }
        }
    }
