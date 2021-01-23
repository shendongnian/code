    try 
    {
       clsFolding.createFolding( /* parameters here */);
       MessageBox.Show("Process Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception Ex)
    {
        MessageBox.Show("Process UnSuccessful", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
    }
