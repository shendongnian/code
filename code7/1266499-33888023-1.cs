    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
       {
            buttonSave_Click(null, null);                
       }
       if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
       {
            buttonEdit_Click(null, null);
       }
    }
