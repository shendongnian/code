    public class MyClass : ReactiveObject
    { 
        private string _name;
        public string Name 
        {
            get { return _name; }
            set { this.RaiseAndSetIfChanged(ref _name, value); 
        }
    
        private string _description;
        public string Description
        {
            get { return _description; }
            set { this.RaiseAndSetIfChanged(ref _description, value); 
        }
    }
