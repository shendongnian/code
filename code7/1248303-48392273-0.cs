    private void Pessoa_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        HasChanged = ValidatePessoa(Pessoa);
    }
    
    ~YourViewModel()
    {
        Pessoa.PropertyChanged -= Pessoa_PropertyChanged;
    }
    bool _hasChanged;
    public bool HasChanged { get => _hasChanged; set => SetProperty(ref _hasChanged, value); }
