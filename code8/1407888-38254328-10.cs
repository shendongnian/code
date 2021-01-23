    public class SaveCommand : ICommand
    {
        private MainWindowsViewModel vm;
        public SaveCommand(MainWindowsViewModel vm)
        {
            this.vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            if (vm.SelectedIndex < 0 || vm.SelectedNote == null)
                return false;
            return vm.ListOfNotes[vm.SelectedIndex].Text != vm.SelectedNote.Text;
        }
        public void Execute(object parameter)
        {
            vm.ListOfNotes[vm.SelectedIndex] = vm.SelectedNote;
        }
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
