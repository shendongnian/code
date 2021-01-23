    public class MyForm : Form
    {
        private IEnumerable<Button> myButtons;
        public MyForm()
        {
            myButtons = new List<Button>
            {
                button0, button1, button2 // etc...
            };
        }
        // etc...
    }
