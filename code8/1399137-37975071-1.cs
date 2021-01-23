    class DatabaseClass
    {
        public static event EventHandler ErrorsChanged;
    
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
                ErrorsChanged(messages, EventArgs.Empty);
            }
        }
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            DatabaseClass.ErrorsChanged += new EventHandler(ErrorItemsChanged);
        }
    
        private void ErrorItemsChanged(Object sender, EventArgs e)
        {
            // This line will be entered if the list has changed.
        }
    }
