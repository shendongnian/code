    try
    {
    }
    catch (Exception ex)
    {
        ShowErrorToUser(ex);
    }
    private void ShowErrorToUser(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
