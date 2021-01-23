    public Visibility FullNameVisibility { get; private set; }
    public ICommand ShowFullNameCommand { get; private set; }
    public StudentViewModel(Student student)
    {
        _Student = student;
        FullNameVisibility = Visibility.Hidden;
        ShowFullNameCommand = new RelayCommand(() => FullNameVisibility = Visibility.Visible);
    }
