    public IEnumerable<OptionViewModel> Options
    {
        get { return optionsAsViewModels ?? (optionsAsViewModels = new List(options.Select(_ => new OptionViewModel { OptionName = _ }))); }
    }
    private IEnumerable<OptionViewModel> optionsAsViewModels;
