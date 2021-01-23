    public class QualCheckState {
        private List<bool> _results = new List<bool>();
        public bool Passed { get { return _results.All(s => s); }
        public void RecordResult(bool result) {
            _results.Add(result);
        }
    }
