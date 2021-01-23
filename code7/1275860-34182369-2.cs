    public class ApplicationViewModel
    {
        ViewModel1 ViewModel1 { get; set; }
        ViewModel2 ViewModel2 { get; set; }
    
        public ApplicationViewModel()
        {
            ViewModel1 = new ViewModel1(someParameters);
            ViewModel2 = new ViewModel2(otherParameters);
    
            ViewModel1.PropertyChanged += VM1_PropertyChanged;
        }
    
        private VM1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ScatterSeries")
                ViewModel2.ScatterSeries = ViewModel1.ScatterSeries;
        }    
    }
