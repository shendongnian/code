    struct ComboItem {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public override string ToString() {
            return FileName;
        }
    }
