     protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.K) && focusedTextbox == subject_TextBox)
            {
               //Some Code
            }
        }
    private TextBox focusedTextbox = null;
     private void subject_TextBox_KeyDown(object sender, KeyEventArgs e)
            {
                MethodName(e.KeyCode)
            } 
     private void MethodName(Keys keys)
        {
            focusedTextbox = (TextBox)sender;
        }
