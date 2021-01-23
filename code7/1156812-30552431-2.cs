    public async Task<Type> MethodAsync(){
        // other code if needed ....
        var helloSign = new HelloSignClient("username", "password");
        Account account = await helloSign.Account.GetAsync();
        Console.WriteLine("Your current callback: " + account.CallbackUrl);
        return type;
    }
