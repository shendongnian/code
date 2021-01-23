    public string ErgebnisBasisPaketPreisString
    {
        get { return _ergebnisBasisPaketPreisString; }
        set 
        {
            _ergebnisBasisPaketPreisString = value;
             OnPropertyChanged(nameof(ErgebnisBasisPaketPreisString));
        }
    }
