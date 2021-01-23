    public partial class Form2 : Form
    {
        public Form2()
        {
            Form3 new3 = new Form3();
            // Access the event of form3 from outsite
            new3.DisplayedItemChanged += ItemChanged;
        }
    
        public void ItemChanged(object sender, EventArgs e)
        {
            // This will be triggered.
        }
    }
    
    public class Form3 : Form
    {
        // Create an event
        public event EventHandler DisplayedItemChanged;
    
        public void button1_Click(object sender, EventArgs e)
        {
            if (this.DisplayedItemChanged != null)
            {
                // Raise the event and pass any object
                this.DisplayedItemChanged(yourObjectToPass, e);
            }
        }
    }
