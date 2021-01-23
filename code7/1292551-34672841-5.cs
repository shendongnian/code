    private void RaiseCanExecuteChanged(object sender, EventArgs e)
    {
            SaveCommand.RaiseCanExecuteChanged();
    }
    public bool CanSave()
    {
        return !this.HasErrors;
    }
    private void OnSave()
    {
        //Your save logic here.
    }
