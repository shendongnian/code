    public class CustomDatePicker : DatePicker
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Template != null)
            {
                var box = (TextBox)Template.FindName("PART_TextBox", this);
                box.AddHandler(KeyDownEvent, new KeyEventHandler(OnTextBoxKeyDown), true);
            }
        }
        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // The DatePicker set this as handled, which breaks the DataGrid commit model.
                e.Handled = false;
            }
        }
    }
