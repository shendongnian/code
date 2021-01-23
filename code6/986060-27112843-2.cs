    public class CustomEntry : Entry
    {
        private CustomEntryParams parameters { get; set; }
        public CustomEntry(CustomEntryParams customParams)
        {
            if (customParams.MaxLength > 0)
            {
                base.TextChanged += EnforceMaxLength;
                parameters = customParams;
            }
        }
        public void EnforceMaxLength(object sender, TextChangedEventArgs args)
        {
            Entry e = sender as Entry;
            String val = e.Text;
            if (val.Length > parameters.MaxLength)
            {
                val = val.Remove(val.Length - 1);
                e.Text = val;
            }
        }
    }
    public class CustomEntryParams {
        public int MaxLength { get; set; }
    }
