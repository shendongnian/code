    public class CstmTextBox : Control
    {
        public string LabelText
        {
            get
            {
                return (string)GetValue (LabelTextProperty);
            }
            set
            {
                SetValue (LabelTextProperty, value);
            }
        }
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register ("LabelText", typeof (string), typeof (CstmTextBox), new PropertyMetadata (string.Empty));
        public string Text
        {
            get
            {
                return (string)GetValue (TextProperty);
            }
            set
            {
                SetValue (TextProperty, value);
            }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register ("Text", typeof (string), typeof (CstmTextBox), new PropertyMetadata (string.Empty));
    }
