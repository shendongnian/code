    public class DatabaseClass
    {
        // Use extended List here.
        public static ListEx<string> messages = new ListEx<string>();
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            DatabaseClass.messages.OnItemChange += new EventHandler(ItemChanged);
        }
    
        public void ItemChanged(Object sender, EventArgs e)
        {
            // Will be raised.
        }
    }
