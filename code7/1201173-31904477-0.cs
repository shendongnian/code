    class Student : INotifyPropertyChanged
    {
        ICommand AddCommand    { get; private set; }
        ICommand RemoveCommand { get; private set; }
    
        public Student()
        {
            this.AddCommand = new RelayCommand(Add);
            this.RemoveCommand = new RelayCommand(Remove);
        }
    
        private Add()
        {
            this.CValue++;
        }
    
        private Remove()
        {
            this.CValue--;
        }
        //snip rest of Student properties
    }
