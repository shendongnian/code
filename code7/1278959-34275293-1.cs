    namespace ChainOfResponsibility
    {
        public partial class Form1 : Form
        {
            ...
            private void AddToList(IEnumerable<string> messages)
            {
                listBox1.Items.AddRange(messages);
    
                ...
            }
        }
    }
