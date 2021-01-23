        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);
            var txt = e.Text.Replace(",", "");
            e.Handled = !IsTextAllowed(txt);
            if (IsTextAllowed(txt))
            {
                if (Text.Length == 3)
                {
                    Text = Text.Insert(1,",");
                    SelectionLength = 1;
                    SelectionStart += Text.Length;
                }
            }
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Back)
            {
                if (Text.Length == 5)
                {
                    Text = Text.Replace(",", "");
                    SelectionLength = 1;
                    SelectionStart += Text.Length;
                }
            }
        }
 
        protected override void OnTextChanged(TextChangedEventArgs e)
        {            
            var txt = Text.Replace(",", "");
            SetValue(ValueProperty, txt.Length==0?0:double.Parse(txt));
            base.OnTextChanged(e);
        }
        private static bool IsTextAllowed(string text)
        {
            try
            {
                double.Parse(text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
