    public class TestClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string property;
        public string Property 
		{ 
			get { return property; }
            set
            {
                property = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Property)));
            }
        }
    }
