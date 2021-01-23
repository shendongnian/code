    class DatabaseClass
    {
        public static event EventHandler ItemsChanged;
    
        private static List<string> messages = new List<string>();
        public static List<string> Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
                ItemsChanged(messages, EventArgs.Empty);
            }
        }
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            DatabaseClass.ItemsChanged += new EventHandler(ItemsChanged);
        }
    
        private void ItemsChanged(Object sender, EventArgs e)
        {
            // This line will be entered if the list has changed.
        }
    }
