    public class CustomEntry : Entry
    {
        public int MaxLength { get; set; }
        public bool IsNumeric { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public CustomEntry()
        {
            // Initialize properties.
            IsNumeric = false;
            MaxLength = int.MaxValue;
            MinValue = int.MinValue;
            MaxValue = int.MaxValue;
            
            // Set the events.
            base.TextChanged += OnTextChanged;
        }
       public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            // If empty, set it to empty string.
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                entry.Text = string.Empty;
                return;
            }
            // Check if it is numeric.
            if (IsNumeric)
            {
                int value;
                var isValid = int.TryParse(e.NewTextValue, out value);
                if (!isValid)
                {
                    entry.Text = e.OldTextValue;
                    return;
                }
                // Check the min/max values.
                if (value > MaxValue || value < MinValue)
                {
                    entry.Text = e.OldTextValue;
                }
            }
            // If not numeric, check the length.
            if (e.NewTextValue.Length > MaxLength)
                entry.Text = e.OldTextValue;
        }
    }
