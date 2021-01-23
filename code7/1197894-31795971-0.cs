    try 
        {
            int numericID = Convert.ToInt32(titleID);
        }
        catch(Exception)
        {
            errorHandling("Invalid Title");
            return; // <---- perhaps you wanted to put the return here?
        }
    void errorHandling(string error)
    {
        MessageBox.Show("You have encountered an error: " + error, "Error");
        // return; <-- does nothing
    }
