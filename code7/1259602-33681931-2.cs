    public class SelectAllTextBoxBehavior : DependencyObject, IBehavior
    {
        private TextBox textBox;
        public DependencyObject AssociatedObject
        {
            get
            {
                return this.textBox;
            }
        }
        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is TextBox)
            {
                this.textBox = associatedObject as TextBox;
                this.textBox.GotFocus += TextBox_GotFocus;
            }
        }
        public void Detach()
        {
            if (this.textBox != null)
            {
                this.textBox.GotFocus -= TextBox_GotFocus;
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBox.SelectAll();
        }
    }
