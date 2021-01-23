    public bool connectToDatabase(Button inputButton, TextBox inputDatabaseBox)
    {
        bool status = false;
        
        theButton = inputButton;
        try
        {
            Console.WriteLine("Attempting to open connection...");
            //THIS IS WHERE I GET STUCK THE SECOND TIME
            if (cnn.State != ConnectionState.Open)
            {
                cnn.Open();
            }
            Console.Write("I opened the connection!");
            currentlyConnectedToADatabase = true;
            displayRowsOfDatabase(inputDatabaseBox);
            theButton.Text = "Connected";
            status = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Cannot open connection!");
        }
        finally
        {
            cnn.Close();
        }
        
        return status;
    }
