     private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control) {                
                removeSpaces();
            }
            //Handle Ctrl+Ins
            if (e.KeyCode == Keys.Control && e.KeyCode == Keys.Insert)
            {
                removeSpaces();
            } 
        }
    private void removeSpaces()
        {
            textBox.Text = textBox.Text.Replace(" ", string.Empty);
        }
