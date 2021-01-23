    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<User> items;
        public List<User> Items 
        {
             get {return items; }
             set {items=value;  onPropertyChanged(this, "Items") }; 
        }
        someEventHandler
        {
             items.Add(new User() { Name = "John", Age = 42 });
             onPropertyChanged(this, "Items") 
        }
    
    
        // Declare the PropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;
    
        // OnPropertyChanged will raise the PropertyChanged event passing the
        // source property that is being updated.
        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
