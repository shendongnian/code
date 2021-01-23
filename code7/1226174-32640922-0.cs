        public partial class Form1 : Form
            {
                FormatComboBox fbox = new FormatComboBox();
                
                // Associate event handler to the combo box.
                fbox.SelectedValueChanged+=FormatComboBox_SelectedValueChanged;
    
            prviate void FormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
              {
                  // do stuff
              }
            }
   
