    public partial class Form1 : Form
    {
        public class ListItem
        {
            public string Text { get; set; }
            public UserControl Value { get; set; }
            public ListItem(string text, UserControl value)
            {
                Text = text;
                Value = value;
            }
        };
        ...
    }
