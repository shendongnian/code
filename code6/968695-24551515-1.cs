    protected void ShowViewModel<TViewModel>(object parameter)
        where TViewModel : IMvxViewModel
    {
        var text = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(parameter);
        base.ShowViewModel<TViewModel>(new Dictionary<string, string>()
            {
                {ParameterName, text}
            });
    }
