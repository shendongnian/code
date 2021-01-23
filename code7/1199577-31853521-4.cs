    public class ViewModelBase : BindableBase
    {
          public virtual IDialogService DialogService 
          { 
             get { return AppContext.Current.DialogService; } 
          }
    }
