    public class DC : INotifyPropertyChanged
    {
        // access to you Func<string> is simply via a property
        // this can be used by setting the binding in code or in XAML
        public string Allele
        {
            get { return MyFunc(); }
        }
        // whenever a variable used in your function changes, raise the property changed event
        private int I
        {
            get { return i; }
            set { i = value; OnPropertyChanged("Allele"); }
        }
        private int i;
        public void Modify()
        {
            // by using the property, the change notification is done implicitely
            I = I + 1;
        }
        // this is your private int AllelePopulation(IAllele allele) function
        private string MyFunc()
        {
            return (I*2).ToString();
        }
        // property changed notification
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
