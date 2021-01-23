    public class ApplicationViewModel
    {
        ViewModel1 ViewModel1 { get; set; }
        ViewModel2 ViewModel2 { get; set; }
        private IEnumerable<Series> _myScatterSeries;
    
        public ApplicationViewModel()
        {
            _myScatterSeries = new Collection<Series>(); 
            ViewModel1 = new ViewModel1(someParameters, _myScatterSeries);
            ViewModel2 = new ViewModel2(otherParameters, _myScatterSeries);
        }   
    }
