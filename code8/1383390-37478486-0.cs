    public event PropertyChanged
    {
        add { _backing.PropertyChanged += value; }
        remove { _backing.PropertyChanged -= value; }
    }
