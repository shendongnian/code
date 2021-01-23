    public string ErgebnisBasisPaketPreisString
    {
        get { return BasisPaketPreis[(int) Basispaket] * (BasisPaketInterval + 1)).ToString("C0"); }
    }
    public string Basispaket
    {
        get { return _basispaket; }
        set 
        {
            _basispaket = value;
             OnPropertyChanged(nameof(Basispaket));
             OnPropertyChanged(nameof(ErgebnisBasisPaketPreisString));
        }
    }
    // and similar for the other properties that are used in the computation
