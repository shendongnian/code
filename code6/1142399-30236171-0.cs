      public class ComboBoxItem
        {
        private string displayName;
        private int value;
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        public ComboBoxItem()
        {
        }
        public ComboBoxItem(string name, int value)
        {
            this.displayName = name;
            this.value = value;
        }
        **public override bool Equals(object obj)
        {
            return (obj is ComboBoxItem) && (obj as ComboBoxItem).Value.Equals(this.Value);
        }**
    }
