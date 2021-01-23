    private ObservableCollection<SubClass1> _SubClass1Objs ;
    public ObservableCollection<SubClass1> SubClass1Objs {
            get { if (_SubClass1Objs== null) _SubClass1Objs = new ObservableCollection<SubClass1>(); return _SubClass1Objs; }
            set { if (_SubClass1Objs!= value) { _SubClass1Objs= value; RaisePropertyChanged("SubClass1Objs"); } } 
    }
