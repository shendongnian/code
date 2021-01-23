     public Form1()
        {
            InitializeComponent();
            this.MouseDown += MouseDownFunction;
            this.MouseUp += MouseUpFunction;
        }
         private void MouseDownFunction(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Do something on Left Mouse Down
            }            
        }
        private void MouseUpFunction(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Do something on Left Mouse up
            }
        }
