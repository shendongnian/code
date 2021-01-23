    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/Root")]
    public class Root
    {
        [OnDeserialized]
        internal void OnSerializingMethod(StreamingContext context)
        {
            if (Table == null)
            {
                Table = new List<TableStructure>();
            }
        }
        [DataMember(Name = "RowGap")]
        internal int RowGap { get; set; }
        [DataMember(Name = "TableHeaderBackgroundColor")]
        internal string HdrBackColor { get; set; }
        [DataMember(Name = "Tables")]
        internal List<TableStructure> Table { get; set; }
    }
    [DataContract(Name = "Table", Namespace = "http://schemas.datacontract.org/2004/07/Root")]
    public sealed class TableStructure
    {
        [DataMember(Name = "StartingColumn")]
        public string TableHeading { get; set; }
        [DataMember(Name = "TableHeading")]
        public string StartingColumn { get; set; }
    }
