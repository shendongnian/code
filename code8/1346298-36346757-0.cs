    public partial class Calculator : UserControl
    {
        //create an event
        public event EventHandler<KeyPressEventArgs> OnKeyPressed;
        public Calculator()
        {
            InitializeComponent();
        }
        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            //raise the event when the key press happens and someone is listening
            if (OnKeyPressed != null)
            {
                OnKeyPressed(sender, e);
            }
        }
    }
