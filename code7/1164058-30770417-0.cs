    class CheatObject {
        public string Name { get; set; }
        public string SelectType { get; set; } // or use enum for this
        public string OffsetStr{ get; set; }
        public string ByteStr { get; set; }
        public ExportToFile() {
            // logic to export a CheatModel
        }
    }
    ...
