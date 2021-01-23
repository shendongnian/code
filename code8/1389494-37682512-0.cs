    //Create a delegate
        public delegate void ButtonClickToOtherForm(object sender, EventArgs e);
    
        public partial class Form2 : Form
        {
            //Your own event based on created delegate
            public event ButtonClickToMainForm ButtonClickedToMainForm;
    
            public Form2()
            {
                InitializeComponent();
            }
    
           //This method will invoke your event
            private void OnButtonClickedToOtherForm(object sender, EventArgs e)
            {
                ButtonClickedToOtherForm?.Invoke(this, e);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //On button1_Click this will fire the event on the other form
                OnButtonClickedToMainForm(this, e);
            }
