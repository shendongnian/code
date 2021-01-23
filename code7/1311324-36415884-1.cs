    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (CurrentCell != null && CurrentCell.IsInEditMode)
        {
            if (keyData == (Keys.Escape))
            {
                CurrentCell.Value = valueBeforeEdit;
                EditingControl.Text = valueBeforeEdit.ToString();
                EndEdit();
    
                return true;
            }
        }
    
        return base.ProcessCmdKey(ref msg, keyData);
    }
