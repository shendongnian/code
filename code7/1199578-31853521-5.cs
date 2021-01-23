    public class HomePageViewModel : ViewModelBase
    {
          ...
          public void Cancel_CommandExecute()
          { 
             var dlgResult = DialogService.ShowMessageBox("Do you really want to discard unsaved changes?", "Confirm Exit", DialogButtons.YesNo);
             if (dlgResult != MessageBoxResult.Yes) return;
          }
    }
