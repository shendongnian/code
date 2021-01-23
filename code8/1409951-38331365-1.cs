    private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Clipboard.SetText(e.Parameter as string);
    }
    private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.Parameter as string))
        {
            e.CanExecute = true;
            e.Handled = true;
        }
    }
