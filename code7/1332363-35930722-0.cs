    public class Form1 {
      
       public Form1() {
          InitializeComponent();
       }
       
       // SomeButton is Clicked
       public void SomeButton_Click(object sender, EventArgs e) {
          // SomeButton is disabled
          SomeButton.Enabled = false;
          // Form2 is created
          var form2 = new Form2();
          // Subscribing to Form2's Closed event
          form2.Closed += OnClosed;
       }
        private void OnClosed(object sender, EventArgs eventArgs)
        {
            // Event is fired and you can enable the button
            SomeButton.Enabled = true;
        }
    }
