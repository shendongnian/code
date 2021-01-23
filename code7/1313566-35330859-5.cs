    try 
    {
       clsFolding.createFolding( /* parameters here */);
       MessageBox.Show("Process Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (SqlException)
    {
        MessageBox.Show("Process UnSuccessful, could not write to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
    }
    catch (Exception Ex)
    {
        MessageBox.Show("Process UnSuccessful, a non-database error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
    }
