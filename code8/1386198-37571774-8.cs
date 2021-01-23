    RelayCommand<System.Windows.Controls.ComboBox> _clearCombo;
    public ICommand ClearCombo
    {
        get
        {
            if (_clearCombo == null)
            {
                _clearCombo = new RelayCommand<System.Windows.Controls.ComboBox>(this.ClearComboCommandExecuted,
                param => this.ClearComboCommandCanExecute());
            }
            return _clearCombo;
        }
    }
    private bool ClearComboCommandCanExecute()
    {
        return true;
    }
    private void ClearComboCommandExecuted(System.Windows.Controls.ComboBox cb)
    {
        cb.Text = "";
    }
