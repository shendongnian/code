    private async Task<bool> LoginServiceAsync(string username, string password)
    {
        string ConnectionName = "Username-Password-Authentication";
        try {
            var result = await auth0.LoginAsync(
                connection: ConnectionName, userName: username, password: password);
            Messenger.Default.Send<UpdateLoginMessage>(new UpdateLoginMessage());
            return true;                  
        } catch {
            return false;
        }
    }
