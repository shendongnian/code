    var sfd= new SaveFileDialog();
    // Other initializations ...
    var result = sfd.ShowDialog();
    if(result== System.Windows.Forms.DialogResult.OK)
    {
        MessageBox.Show("Save Clicked");
    }
    else
    {
        MessageBox.Show("Cancel Clicked");
    }
