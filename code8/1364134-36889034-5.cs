    private void button_Click(object sender, RoutedEventArgs e)
    {
        bool authenticated = false;
        try
        {
            AuthText = "Authenticating...";
            authenticated = Authenticate(); // Stuff happens
        }
        finally
        {
            AuthText = authenticated ? "Authenticated" : "Oops!";
        }
    }
    bool Authenticate()
    {
        // Return if auth was successful
    }
