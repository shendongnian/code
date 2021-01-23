    public class CustomEntry : Entry
    {
        public int MaxLength { get; set; }
        public bool IsNumeric { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public CustomEntry()
        {
            base.TextChanged += OnTextChanged;
        }
        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                entry.Text = string.Empty;
                return;
            }
            if (e.NewTextValue.Length > MaxLength)
                entry.Text = e.OldTextValue;
            // Check if it is numeric.
            if(IsNumeric)
            {
                int value;
                var isValid = int.TryParse(e.NewTextValue, out value);
                if (!isValid)
                {
                    entry.Text = e.OldTextValue;
                    return;
                }
                // Check the min/max values.
                if(value > MaxValue || value < MinValue)
                {
                    entry.Text = e.OldTextValue;
                }
            }
            
        }
    }
