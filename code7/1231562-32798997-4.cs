    public class RecordSetContainer
    {
        public RecordSetContainer()
        {
            RecordSet1 = new List<MultipleRecordSetStoredProcedureReturnType1>();
            RecordSet2 = new List<MultipleRecordSetStoredProcedureReturnType2>();
            RecordSet3 = new List<MultipleRecordSetStoredProcedureReturnType3>();
        }
        public List<MultipleRecordSetStoredProcedureReturnType1> RecordSet1 { get; set; }
        public List<MultipleRecordSetStoredProcedureReturnType2> RecordSet2 { get; set; }
        public List<MultipleRecordSetStoredProcedureReturnType3> RecordSet3 { get; set; }
    }
