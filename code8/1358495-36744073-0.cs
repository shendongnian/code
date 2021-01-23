    public class SectionItem
    {
        public string Title { get; set; }
        public int ID { get; set; }
    
        private ObservableCollection<Option> _options;
        public ObservableCollection<Option> Options
        {
            get { return _options ?? (_options = new ObservableCollection<Option>()); }
        }
    }
    
    public class Option
    {
        public string Name { get; set; }
        public ObservableCollection<ProductCalculatorTemplate> Products
        {
            get { return _products ?? (_products = new ObservableCollection<ProductCalculatorTemplate>()); }
        }
    }
