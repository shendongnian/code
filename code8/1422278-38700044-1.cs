    public class MyPageViewModel : ViewModelBase
    {
      private string _selectedText;
      public string SelectedText
      {
        get { return _selectedText; }
        set
        {
          if (_selectedText != value)
          {
            _selectedText = value;
            RaisePropertyNotifyChanged(); // However you're doing this.
          }
        }
      }
      public MyPageViewModel()
      {
        _selectedText = "Welcome";
        var _ = RunSomeTask();
      }
      private async Task RunSomeTask()
      {
        try
        {
          SelectedText = await SomeTask();
        }
        catch (Exception ex)
        {
          // TODO: Handle the exception.
          // It *must* be handled here, or else it will be silently ignored!
        }
      }
      private async Task<string> SomeTask()
      {            
        await Task.Delay(3000);
        return "Thanks";
      }
    }
