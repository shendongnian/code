    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = !PromptUnsavedChanges();
    }
    private bool PromptUnsavedChanges()
    {
        if (HasFormChanged()) //checks if form is different from the DB
        {
            DialogResult dr = MessageBox.Show("You have unsaved changes. Would you like to save them?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Yes)
                tsmiSave_Click(null, null); // Saves the data
            else if (dr == System.Windows.Forms.DialogResult.Cancel)
                return false; // Cancel the closure of the form, but don't save either
        }
        return true; // Close the form
    }
