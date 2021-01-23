    public class SelectableTextBox : TextBox
    {
        public SelectableTextBox()
        {
            this.GotFocus += SelectableTextBox_GotFocus;
        }
    
        private void SelectableTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SelectAll();
        }
    }
