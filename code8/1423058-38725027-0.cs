    public class ScenariosViewModel : BindableBase
    {
      public ScenariosViewModel()
      {
        SaveCommand = new DelegateCommand(async () => await SaveAsync());
        RefreshCommand = new DelegateCommand(async () => await LoadDataAsync());
      }
      public async Task LoadDataAsync()
      {
        IsLoading = true;
        try
        {
          Scenarios = await Task.Run(() => _service.AllScenarios());
        }
        finally
        {
          IsLoading = false;
        }
      }
      private async Task SaveAsync()
      {
        IsLoading = true;
        await Task.Run(() => _service.Save(_selectedScenario));
        await LoadDataAsync();
      }
    }
