        public Chapter10Ex2()
        {
            InitializeComponent();           
            amplify.HighestValue = 0;           
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {          
            newValue = trackBar1.Value;                   
        }       
        private void MouseUp(object sender, MouseEventArgs e)
        {          
            amplify.NewValue(newValue);
            lblMinMax.Text = amplify.LowestValue.ToString() + " , " + amplify.HighestValue.ToString();
        }
