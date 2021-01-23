    /// <summary>
    /// Will validate that the text entered into an Entry is a valid number string (allowing: numbers and colons).
    /// </summary>
    public class IntColonValidationBehavior : Behavior<Entry> {
        public static IntColonValidationBehavior Instance = new IntColonValidationBehavior();
        /// <summary>
        /// Attaches when the page is first created.
        /// </summary>
        protected override void OnAttachedTo(Entry entry) {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        /// <summary>
        /// Detaches when the page is destroyed.
        /// </summary>
        protected override void OnDetachingFrom(Entry entry) {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        private void OnEntryTextChanged(object sender, TextChangedEventArgs args) {
            if(!string.IsNullOrWhiteSpace(args.NewTextValue)) {
                int  result;
                string valueWithoutColon = args.NewTextValue.Replace(":", string.Empty);
                bool isValid = int.TryParse(valueWithoutColon, out result);
                ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }
    }
