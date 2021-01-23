    class StudentsVM: INotifyPropertyChanged
    {
        ICommand AddCommand    { get; private set; }
        ICommand RemoveCommand { get; private set; }
    
        public StudentsVM()
        {
            this.AddCommand = new RelayCommand<Student>(Add);
            this.RemoveCommand = new RelayCommand<Student>(Remove);
        }
    
        private Add(Student student)
        {
            student.CValue++;
        }
    
        private Remove(Student student)
        {
            student.CValue--;
        }
        //snip rest of Student properties
    }
