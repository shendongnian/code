    public class MyClass
    {        
        const int ThrottlePeriod = 500; // ms
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                SearchWithDelay();              
            }
        }
        private async void SearchWithDelay() {
            var before = this.SearchTerm;
            await Task.Delay(ThrottlePeriod);
            if (before == this.SearchTerm) {
                // did not change while we were waiting
                ExecuteRequest();
            }
        }        
        private void ExecuteRequest()
        {
            Console.WriteLine(SearchTerm);
        }
    }
