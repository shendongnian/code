    try
    {
        // your actual code
    }
    catch (Exception ex)
    {
        // show it to the user
        MessageBox.Show(ex.Message);
        // reset progress bar
        toolStripProgressBar1.ProgressBar.Value = 0;
    }
