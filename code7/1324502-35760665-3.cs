    foreach (var obj in objects)
    {
        Console.WriteLine(obj.user.FirstName);
        Console.WriteLine(obj.user.LastName);
        // and so on all user properties
        Console.WriteLine(obj.image.Height); // just example
    }
