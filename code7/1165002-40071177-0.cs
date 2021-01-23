    public class ComboBoxAutoSelect : ComboBox
    {
        private TextBoxBase textBox;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            textBox = GetTemplateChild("PART_EditableTextBox") as TextBoxBase;
        }
        protected override void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            // if event is called from ComboBox itself and not from any of underlying controls
            // and if textBox is defined in control template
            if (e.OriginalSource == e.Source && textBox != null)
            {
                textBox.Focus();
                textBox.SelectAll();
                e.Handled = true;
            }
            else
            {
                base.OnPreviewGotKeyboardFocus(e);
            }
        }
    }
