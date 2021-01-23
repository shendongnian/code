     public class CustomItem
     {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    
        public CustomItem(string text, int value)
        {
            this.Text = text;
            this.Value = value;
        }
    }
