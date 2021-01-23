    private string m_Note;
    public string Note
    {
        get { return m_Note; }
        set
        {
            m_Note = value;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Note"));
        }
    } 
