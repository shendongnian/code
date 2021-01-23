    var saveFileDialog = new SaveFileDialog();
    // Other initializations ...
    var result = saveFileDialog.ShowDialog();
    if(result== System.Windows.Forms.DialogResult.OK)
    {
        MessageBox.Show("Save Clicked");
    }
    else
    {
        MessageBox.Show("Cancel Clicked");
    }
