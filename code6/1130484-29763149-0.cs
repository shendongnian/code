    string line = null;
    do {
        Console.WriteLine("Which Room Would you like to Trigger? \nRoom 1001 or Room 1002");
        line = Console.ReadLine();
        if (line == "1001")
        {
          await objClient.WritePropertyAsync(fqrs[0], "Present Value", a_bOn ? "on" : "off", CancellationToken.None);
          Console.WriteLine("You have Triggered Room 1001");
        }
        else if (line == "1002")
        {
          await objClient.WritePropertyAsync(fqrs[1], "Present Value", a_bOn ? "on" : "off", CancellationToken.None);
          Console.WriteLine("You have Triggered Room 1002");
        }
    } while (line != "exit")
