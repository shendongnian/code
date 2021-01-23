    public UserControlx : UserControl
    {
        public event EventHandler Click;
        
        public UserControlx()
        {
            Button.Click += Button_Click;
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            if(Click != null)
                Click(this, EventArgs.Empty);
        }
    }
