    public class LinkedTextBox : TextBox
    {
        #region TextBoxA Property
        public TextBox TextBoxA
        {
            get { return (TextBox)GetValue(TextBoxAProperty); }
            set { SetValue(TextBoxAProperty, value); }
        }
        public static readonly DependencyProperty TextBoxAProperty =
            DependencyProperty.Register("TextBoxA", typeof(TextBox), typeof(LinkedTextBox),
                new PropertyMetadata(null));
        #endregion TextBoxA Property
    }
