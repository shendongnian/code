    public interface IDialogViewModel
    {
        void PreOpenDialog();
        void PostOpenDialog(bool? dialogResult);
    }
    public class ShowDialogCommand : OpenWindowCommand
    {
        private readonly IDialogViewModel _ViewModel;
        public ShowDialogCommand(IDialogViewModel viewModel)
        {
            _ViewModel = viewModel;
        }
        protected override void OpenWindow(System.Windows.Window wnd)
        {
            //Do the pre open dialog method before showing the dialog
            _ViewModel.PreOpenDialog();
            //Show the dialog
            bool? result = wnd.ShowDialog();
            //Send the result to the post open dialog method.
            _ViewModel.PostOpenDialog(result);
        }
    }
