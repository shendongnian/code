      List<Message> result = new List<Message>();
      UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
      request.Q = query;//This is where you put in your data query
      do
      {
          try
          {
              ListMessagesResponse response = request.Execute();
              result.AddRange(response.Messages);
              request.PageToken = response.NextPageToken;
          }
          catch (Exception e)
          {
              Console.WriteLine("An error occurred: " + e.Message);
          }
      } while (!String.IsNullOrEmpty(request.PageToken));
