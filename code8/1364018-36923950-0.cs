    public class TextBoxNumericalOnlyBehavior : Behavior<Control>
        {
            private TextBox textBox;
    
            public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(Double), typeof(TextBoxNumericalOnlyBehavior),
            new FrameworkPropertyMetadata(Double.MaxValue));
    
            public Double MaxValue
            {
                get
                {
                    return (Double)base.GetValue(MaxValueProperty);
                }
                set
                {
                    base.SetValue(MaxValueProperty, value);
                }
            }
    
            public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(Double), typeof(TextBoxNumericalOnlyBehavior),
            new FrameworkPropertyMetadata(Double.MinValue));
    
            public Double MinValue
            {
                get
                {
                    return (Double)base.GetValue(MinValueProperty);
                }
                set
                {
                    base.SetValue(MinValueProperty, value);
                }
            }
    
            public static readonly DependencyProperty RegularExpressionProperty =
            DependencyProperty.Register("RegularExpression", typeof(string), typeof(TextBoxNumericalOnlyBehavior),
            new FrameworkPropertyMetadata(".*"));
            public string RegularExpression
            {
                get
                {
                    return (string)base.GetValue(RegularExpressionProperty);
                }
                set
                {
                    base.SetValue(RegularExpressionProperty, value);
                }
            }
    
            protected override void OnAttached()
            {
                base.OnAttached();
    
                AssociatedObject.Loaded += AssociatedObject_Loaded;
                AssociatedObject.Unloaded += AssociatedObject_Unloaded;
                AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
                AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
                DataObject.AddPastingHandler(AssociatedObject, OnPaste);
            }
    
            private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
            {
                // to do
            }
    		
    		private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
            {
                // to do
            }
    
            private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (this.textBox != null)
                {
                    if (e.Key == Key.Space || e.Key == Key.Delete)
                    {
                        e.Handled = true;
                    }
                    else if (e.Key == Key.Back)
                    {
                        e.Handled = !IsValid(string.Empty, false, true);
                    }
                }
            }
    
            private void AssociatedObject_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                if (this.textBox != null)
                {
                    e.Handled = !IsValid(e.Text, false, false);
                }
            }
    
            private void OnPaste(object sender, DataObjectPastingEventArgs e)
            {
                if (e.DataObject.GetDataPresent(DataFormats.Text))
                {
                    string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
    
                    if (!IsValid(text, true, false))
                    {
                        e.CancelCommand();
                    }
                }
                else
                {
                    e.CancelCommand();
                }
            }
    
            private bool IsValid(string text, bool paste, bool back)
            {
                if(this.textBox.Text == null)
                {
                    return false;
                }
    
                int caretIndex = this.textBox.CaretIndex;
                int selectionStart = this.textBox.SelectionStart;
                int selectionLength = this.textBox.SelectionLength;
    
                string newValue = string.Empty;
    
                // on paste 
                if (paste && selectionLength > 0)
                {
                    string tempValue = this.textBox.Text.Remove(selectionStart, selectionLength);
                    newValue = tempValue.Insert(caretIndex, text.Trim());
                }
                // on back
                else if (back)
                {
                    // check if textbox is empty
                    if (this.textBox.Text.Equals(string.Empty))
                    {
                        return true;
                    }
    
                    newValue = this.textBox.Text.Remove(selectionStart == 0 ? selectionStart : selectionStart - 1,
                        selectionLength == 0 ? 1 : selectionLength);
                }
                else
                {
                    newValue = this.textBox.Text.Insert(caretIndex, text.Trim());
                }
    
                return IsInRange(newValue);
            }
    
            private bool IsInRange(string text)
            {
                Double result = 0;
    
                if (text.Equals(string.Empty))
                {
                    return true;
                }
    
                if (Regex.IsMatch(text, this.RegularExpression))
                {
                    if (Double.TryParse(text, out result))
                    {
                        return result <= this.MaxValue && result >= this.MinValue;
                    }
                }
    
                return false;
            }
    }
