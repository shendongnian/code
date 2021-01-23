     public Form1()
            {
                InitializeComponent();
                //Subscribe to event from your usercontrol
                userControl11.ButtonClickedToMainForm += UserControl11_ButtonClickedToMainForm;
            }
    
            //Button on userControl1 has been clicked
            private void UserControl11_ButtonClickedToMainForm(object sender, EventArgs e)
            {
                //do your things here...
            }
