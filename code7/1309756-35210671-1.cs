    public class ViewModel
    {
        public string Name { set; get; }
    
        public List<SimpleViewModel> Parameters
        {
            set
            {
                parameters = value;
            }
            get
            {
                return parameters;
            }
        }
    
        private List<SimpleViewModel> parameters;
    
        public ViewModel()
        {
            Parameters = new List<SimpleViewModel>();
        }
    
        public List<SimpleViewModel> NotDeletedParameters{ 
             get {
                   return parameters .Where(t => !t.Deleted).ToList();
                 }
        }
    }
