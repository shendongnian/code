    // Make the class name readable, use upper case (FormPopup instead of formpopup):
    public partial class FormPopup : Form {
      public FormPopup() {
        InitializeComponent();
      }
    
      //TODO: rename the button as well as the textbox 
      private void button1_Click(object sender, EventArgs e) {
        if (textBox1.Text == "1234") 
          DialogResult = System.Windows.Forms.DialogResult.OK;
        else
          DialogResult = System.Windows.Forms.DialogResult.Cancel;
    
        // In case form was open as non-dialog
        Close();
      } 
    }
    
    ....
    
    public partial class Form1 : Form {
      ...
      private void button1_Click(object sender, EventArgs e) {
        // Wrap IDisposable into using
        using (FormPopup dialog = new FormPopup()) {
          if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) 
            return; // wrong password
        }
    
        // Wrap IDisposable into using
        using (OpenFileDialog fileDialog = new OpenFileDialog()) {
          if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            //TODO: put relevant code here
          }
        }
      }
    }
