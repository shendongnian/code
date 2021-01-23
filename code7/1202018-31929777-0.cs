    private static async Task<string> GetToken(string authority, string resource, string scope) // I don't control this signature, as it gets passed as a delegate
    {
        using (var tcs = new TaskCompletionSource<string>()) {
            Thread t = new Thread(() => GetAuthToken(tcs));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            var token = await tcs.Task
            return token;
        }
    }
    private static void GetAuthToken(TaskCompletionSource<string> tcs)
    {
        try {
           Credentials creds = AuthManagement.CreateCredentials(args); // this call must be STA
           tcs.SetResult(creds.Token);
        }
        catch(Exception ex) {
           tcs.SetException(ex);
        }
    }
