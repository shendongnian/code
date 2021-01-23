    public class TextValidationBehavior : Behavior<Entry>
    {
     // This can be bound to view model property to be informed
     public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;
        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }
    // Attach delegate to text changed event
    protected override void OnAttachedTo(Entry entry)
    {
        entry.TextChanged += OnEntryTextChanged;
        base.OnAttachedTo(entry);
    }
    // Detach delegate from text changed event
    protected override void OnDetachingFrom(Entry entry)
    {
        entry.TextChanged -= OnEntryTextChanged;
        base.OnDetachingFrom(entry);
    }
    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue;
        IsValid = Validate(text); // Implement this as needed
    }
    }
