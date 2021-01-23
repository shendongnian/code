    private Pessoa _pessoa;
    public Pessoa Pessoa
    {
        get { return _pessoa; }
        set 
        {
            if (_pessoa != null)
                _pessoa.PropertyChanged -= PropertyChanged; 
            SetProperty(ref _pessoa, value);
            if (_pessoa != null)
                _pessoa.PropertyChanged += PropertyChanged;
        }
    }
