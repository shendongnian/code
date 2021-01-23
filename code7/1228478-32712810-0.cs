    class IntegerTextBox : TextBox
    {
        private bool controlDown;
        public IntegerTextBox()
        {
            controlDown = false;
            KeyPress += new KeyPressEventHandler(accept_only_digits); //disable "wrong" key presses, http://stackoverflow.com/a/4285768/2436175
            KeyDown += new KeyEventHandler(update_control_status);
            KeyUp += new KeyEventHandler(update_control_status);
        }
        void update_control_status(object sender, KeyEventArgs e)
        {
            controlDown = e.Control;
        }
        void accept_only_digits(object sender, KeyPressEventArgs e)
        {
            if (controlDown)
                {
                return;
                }
            char ch = e.KeyChar;
            //[...]
