    public class MyPageViewModel : ViewModelBase
    {
      private NotifyTask<string> _selectedText;
      public NotifyTask<string> SelectedText => _selectedText;
      public MyPageViewModel()
      {
        _selectedText = NotifyTask.Create(SomeTask(), "Welcome");
      }
      private async Task<string> SomeTask()
      {            
        await Task.Delay(3000);
        return "Thanks";
      }
    }
