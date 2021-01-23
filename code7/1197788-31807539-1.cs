    public class MainVM
    {
        public ObservableCollection<object> Views { get; private set; }
        public MainVM()
        {
            this.Views = new ObservableCollection<object>();
            this.Views.Add(new SearchVM(GotResults));
        }
        private void GotResults(Results results)
        {
            this.Views.Add(new ResultVM(results));
        }
    }
