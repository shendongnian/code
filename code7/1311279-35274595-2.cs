    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace ValidateRadioButton
    {
      public partial class Form1 : Form
      {
    
        // RadioButton that is currently active
        RadioButton ActiveRadioButton;
        bool cancelingChange;
    
        public Form1()
        {
          InitializeComponent();
          activeRadioButton = this.radioButton1;
        }
    
        private void radioButton_CheckedChanged(object sender, System.EventArgs e)
        {
          // Each click fires two events
          // One for the RadioButton loosing its check and the other that is gaining it
          // We are interested in the one gaining it
          if (sender is RadioButton) {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked) {
              // If this button is changing because of a canceled check
              // do not validate
              if (!cancelingChange) {
                cancelingChange = !ValidateData();
                if (!cancelingChange) {
                  // Mark this as the active value
                  activeRadioButton = radioButton;
                }
              }
            }
          }
        }
    
        private void radioButton_Click(object sender, System.EventArgs e)
        {
          // This is called after the RadioButton has changed
          if (cancelingChange) {
            // Check theRadioButton that was previously checked
            activeRadioButton.Checked = true;
            cancelingChange = false;
          }
          else {
            // Do the thing the RadioButton should do
            // If using separate events they all must start with the condition above.
            this.Text = ((RadioButton)sender).Name;
          }
        }
    
        /// <summary>
        /// Validate state of data
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
          bool result = chkAllowChange.Checked;
          if (!result) {
            result = MessageBox.Show("Do you want to save your data?", "CheckBox unchecked", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK;
            if (result) {
              // This is where I would save the data
              chkAllowChange.Checked = true;
            }
          }
          return result;
        }
      }
    }
