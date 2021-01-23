    //Create a delegate
        public delegate void ButtonClickToMainForm(object sender, EventArgs e);
    
        public partial class UserControl1 : UserControl
        {
            //Your own event based on created delegate
            public event ButtonClickToMainForm ButtonClickedToMainForm;
    
            public UserControl1()
            {
                InitializeComponent();
            }
    
           //This method will invoke your event
            private void OnButtonClickedToMainForm(object sender, EventArgs e)
            {
                ButtonClickedToMainForm?.Invoke(this, e);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //On button1_Click this will fire the event on mainform
                ButtonClickedToMainForm(this, e);
            }
