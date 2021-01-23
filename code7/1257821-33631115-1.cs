     using(var client = new TestService.TestServiceClient())
     {
         var response = client.FindUser(username, password);
         //validate the response
     }
