    public class MyClass {
        private readonly Timer _timer;
        const int ThrottlePeriod = 500; // ms
        public MyClass() {
            _timer = new System.Threading.Timer(_ => {
                ExecuteRequest();
            }, null, Timeout.Infinite, Timeout.Infinite);
        }
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                ResetTimer();
            }
        }
        private void ResetTimer() {
            _timer.Change(ThrottlePeriod, Timeout.Infinite);
        }
        private void ExecuteRequest() {
            Console.WriteLine(SearchTerm);
        }
    }
