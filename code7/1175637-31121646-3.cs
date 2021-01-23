    public bool connectToDatabase(Button inputButton, TextBox inputDatabaseBox)
    {
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
                return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Cannot open connection!");
        }
        finally
        {
            cnn.Close();
        }
        
    }
    public void disconnectFromDatabase()
        {
            MessageBox.Show("Disconnected from Database");
            if(cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            theButton.Text = "Connect to Database";
            //theTextBox.Text = "";
            currentlyConnectedToADatabase = false;
        }
