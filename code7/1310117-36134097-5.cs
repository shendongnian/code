    public class ErrorViewModel : ViewModelBase, IErrorViewModel
    {     
    	/*Other piece of code */
    	  
    		public void HomeReturn()
            {
                var msg = new ChangeView(ChangeView.EnumView.Home);
                Messenger.Default.Send<ChangeView>(msg);
                ViewModelLocator.CleanUpErrors();
            }
    }
