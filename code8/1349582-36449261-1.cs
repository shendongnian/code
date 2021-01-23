    UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List("Users email address");
    var response = request.Execute();
    foreach (var item in response.Messages) {
         Console.WriteLine(item.Payload.Headers);            
     }
