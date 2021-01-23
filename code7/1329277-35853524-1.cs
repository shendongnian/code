    public class DialogFactory : IDialogFactory
    {
        private Func<IDialogView> dialogViewFactory;
    
        public DialogFactory(Func<IDialogView> dialogViewFactory)
        {
            this.dialogViewFactory = dialogViewFactory;
        }
    
        public IDialogView CreateDialogView()
        {
            return this.dialogViewFactory();
        }
    }
