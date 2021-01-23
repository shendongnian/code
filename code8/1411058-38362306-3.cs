    public partial class TestForm : Form
    {
        public TestForm()
        {
                // declare and subscribe to the user control
                SaveCancelButtons scb = new SaveCancelButtons();
                scb.SaveClicked += Scb_SaveClicked; ;
                scb.CancelClicked += Scb_CancelClicked; ;
                this.Controls.Add(scb);
    
                InitializeComponent();
        }
    
            private void Scb_CancelClicked(object sender, EventArgs e)
            {
                MessageBox.Show("Cancel");
            }
    
            private void Scb_SaveClicked(object sender, EventArgs e)
            {
                MessageBox.Show("Save!");
            }
    }
