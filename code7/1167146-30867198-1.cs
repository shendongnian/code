        try
        {
            var userList = service.Users.List();
            userList.MaxResults = 10;
            userList.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
