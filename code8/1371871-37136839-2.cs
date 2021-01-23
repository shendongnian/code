     private void subject_TextBox_KeyDown(object sender, KeyEventArgs e)
            {
                MethodName(e.KeyCode)
            } 
     private void MethodName(Keys keys)
        {
            if (keys == (Keys.Control | Keys.K))
            {
                      MessageBox.Show("!");
            }
        }
 
