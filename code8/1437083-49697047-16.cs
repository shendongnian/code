          public partial class CustomDialog : Form // CustomDialog 
             {
               static CustomDialog MsgBox; //used in show method as a reference
                static DialogResult result; //retuned by show method
                
        public CustomDialog()
                 {
                  InitializeComponent();
                  result = DialogResult.OK; //initialise the result according to the function of the button, here I only use the OK button to close the dialog       }
        public static DialogResult show (string calculationResult) // show static method called by the Main Window  
            {
            MsgBox = new CustomDialog();
            MsgBox.result_text.Text = calculationResult; // result_text is a textbox implemented in the form using design view
            MsgBox.StartPosition = FormStartPosition.CenterParent; // center dialog in the middle of the parent (WPF application main window)
            MsgBox.ShowDialog(); // displays the dialog
            return result; // returns the result so the button event is handled 
             }
