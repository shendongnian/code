    //async Task
    public async Task Cleanup(Response response)
    {
         using (var smtpClient = new SmtpClient())
        {
            await smtpClient.SendAsync();...//await
        }
    }
