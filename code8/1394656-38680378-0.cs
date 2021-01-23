    async Task MyMethod()
    {
      using(UserDialogs.Instance.ShowLoading("Loading",MaskType.Black))
      {
        await ViewModel.LoadData();
      }
    }
    //InsideViewModel
    public async Task LoadData();
    {
    await Task.Yield(); //without this code and ios doesnt work
    //download data
    }
