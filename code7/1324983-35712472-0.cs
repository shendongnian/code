    public class WordCountComparer : IComparer<String>
    {
        public Int32 Compare(String a, String b)
        {
            var split = new[] { ' ' };
            
            var aCount = String.IsNullOrWhiteSpace(a) ? 0 : a.Split(split).Length;
            var bCount = String.IsNullOrWhiteSpace(b) ? 0 : b.Split(split).Length;
    
            if (aCount == bCount) { return 0; }
            if (aCount < bCount) { return 1; } else { return -1; }
        }
    }
