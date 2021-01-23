    public class ViewModel
    {
        private Func<IDialogView> dialogViewFactory;
    
        public ViewModel(Func<IDialogView> dialogViewFactory)
        {
            this.dialogViewFactory = dialogViewFactory;
        }
    
        private IDialogView CreateDialogView()
        {
            return this.dialogViewFactory();
        }
    }
