    [FixedLengthRecord()]
    public class FileControlRecord
    {
        [FieldFixedLength(1)]
        public int RecordTypeCode = 9; //Constant
    
        [FieldFixedLength(6)]
        public string BatchCount; //Numeric
    
        [FieldFixedLength(6)]
        public string BlockCount; //Numeric
    
        [FieldFixedLength(8)]
        public string EntryAddendaCount; //Numeric
    
        [FieldFixedLength(10)]
        public string EntryHash; //Numeric
    
        [FieldFixedLength(12)]
        [FieldAlign(AlignMode.Right, '$')]
        public string TotalDebit; //$$$$$$$$$$cc
    
        [FieldFixedLength(12)]
        [FieldAlign(AlignMode.Right, '$')]
        public string TotalCredit; //$$$$$$$$$$cc
    
        [FieldFixedLength(39)]
        public string RESERVED; //Blank
    }
