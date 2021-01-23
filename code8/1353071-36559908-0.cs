    DialogResult result = MessageBox.Show(string.Format("{0} Do you want to save changes?", "Some Name for your Popup Dialog"), "Confirmation", MessageBoxButtons.YesNoCancel);
    if (result == DialogResult.Yes)
    {
        //do work
    }
    else if (result == DialogResult.No)
    {
        //...
    }
    else if (result == DialogResult.Cancel)
    {
        //...
    }
    
