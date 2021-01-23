    private void MLTBTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Text = this.MLTBTextBox.Text; // transfer changes from TextBox to bindable property (bindable property change notification will be fired)
        }
        private static void LabelTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyLabelledTextBox)d).MLTBLabel.Content = (string)e.NewValue; // transfer changes from bindable property to Label
        }
        private static void TextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyLabelledTextBox)d).MLTBTextBox.Text = (string)e.NewValue; // transfer changes from bindable property to TextBox
        }
