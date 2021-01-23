    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            processKey((char) keyData);  // we need the Enter key
            return false;                // do not steal it!
        }
        processKey((char)keyData);       // process other keys
        return base.ProcessCmdKey(ref msg, keyData);
    }
