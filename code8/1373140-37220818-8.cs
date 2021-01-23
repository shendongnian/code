    public class PieChartViewModel
    {
        public ObservableCollection<TestClass> Errors { get; private set; }
        public PieChartViewModel()
        {
            Errors = new ObservableCollection<TestClass>();
        }
    }
