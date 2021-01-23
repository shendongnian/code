    private double _torsion;
    public double Torsion
    {
        get { return _torsion; }
        set
        {
            if (value.Equals(_torsion)) return;
            _torsion = value;
            OnPropertyChanged();
        }
    }
