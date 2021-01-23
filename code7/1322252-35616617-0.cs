    catch (MySql.Data.MySqlClient.MySqlException ex)
    {
        switch (ex.Number)
        {
            case 0:
                MessageBox.Show("Cannot connect to server.  Contact administrator");
                break;
            case 1045:
                MessageBox.Show("Invalid username/password, please try again");
                break;
            case 1169:
                MessageBox.Show("Name already exists");
                //Since you've taken the ignore off you can run whatever you wanted to run here.
        }
    }
