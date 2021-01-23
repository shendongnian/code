    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        if (MessageBox.Show("Wszystkie zmiany zostaną odrzucone", "Odrzucenie Zmian", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
        {
                e.Cancel = true; 
        }
    }
