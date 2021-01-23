        public class DemoItem
    {
        public string ItemDescription
        {
            get
            {
                return LocalizedString.GetText();
            }
            set
            {
                LocalizedString.SetText(value);
            }
        }
        private LocalizedString LocalizedString { get; set; }
    }
