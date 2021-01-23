    public bool CanExecute(object parameter)
    {
        return vm.SelectedNote.Text != parameter as string;
    }
    public void Execute(object parameter)
    {
        vm.SelectedNote.Text = parameter as string;
    }
            
