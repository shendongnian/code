    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control|Keys.Z))
        {
            if (undoList.Count > 0)
            {
                ignoreChange = true;
                richTextBox1.Text = undoList[undoList.Count - 1];
                //richTextBox1.Focus();
                richTextBox1.SelectionStart = 3;
                richTextBox1.SelectionLength = 2;
                richTextBox1.SelectionColor = Color.Green;
                undoList.RemoveAt(undoList.Count - 1);
    
                ignoreChange = false;
 
                // Do not handle base method
                // which will revert the last action
                // that is changing the selection to green.
                return true;
            }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
