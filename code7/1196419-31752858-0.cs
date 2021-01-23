        public class SfdcCollection<T> // No IEnumerable<T>
        {
            public bool Done { get; set; }
            public int Size { get; set; }
            public string NextRecordsUrl { get; set; }
            public List<T> Records { get; set; }
        }
