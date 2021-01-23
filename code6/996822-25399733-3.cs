    public async Task Manipulate () {
         ServiceReference1.Service1Client Client = new ServiceReference1.Service1Client();
         var i = await Client.ManipulateAsync(new ServiceReference1.ManipulateRequest("SQL Command"));
         // to get the result use i.Result;
    }
