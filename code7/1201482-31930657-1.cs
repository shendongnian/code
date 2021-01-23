    public class NumericValidationBehavior : Behavior<YourCustomEntry>
    {
        protected override void OnAttachedTo(YourCustomEntry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
    
        protected override void OnDetachingFrom(YourCustomEntry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
    
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            // Do something with you custom property
            ((YourCustomEntry)sender).YourCustomField = "test";
        }
    }
