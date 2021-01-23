    public class CsvData
    {
        [CsvColumn(FieldIndex = 0)]
        public int x { get; set; }
        [CsvColumn(FieldIndex = 1)]
        public int y { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public int z { get; set; }
    }
