    public Form1()
            {
                InitializeComponent();
                //Subscribe to event from your other Form
                Form2.ButtonClickedToOtherForm += Form2_ButtonClickedToOtherForm;
            }
    
            //Button on Form2 has been clicked
            private void Form2_ButtonClickedToMainForm(object sender, EventArgs e)
            {
                //change your Label Text here...
            }
