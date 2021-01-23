    private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }
    private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Policy_text.Paste();
        }
    
