    public IViewModel TestViewModel
    {
        get { return m_testViewModel; }
        set
        {
            m_testViewModel = value;
            OnPropertyChanged("TestViewModel");
        }
    }
