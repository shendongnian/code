    namespace WpfApplication1
    {
        class ViewModelAll : INotifyPropertyChanged
        {
            private ModelClass _model;
    
            public ObservableCollection<EmployeeList> DataSet
            {
                get;
                private set;
            }
    
            public ViewModelAll()
            {
                _model = new ModelClass();
                DataSet = new ObservableCollection<EmployeeList>();
    
                MyAction();
            }
    
     
            private void MyClose()
            {
                Application.Current.MainWindow.Close();
            }
    
            public void MyAction()
            {
                foreach (var datum in _model.GetDataSet())
                {
                    DataSet.Add(datum);
                }
            }
    
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(string property)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (PropertyChanged == null) return;
    
                handler(this, new PropertyChangedEventArgs(property));
            }
            #endregion INotifyPropertyChanged
        }
    }
