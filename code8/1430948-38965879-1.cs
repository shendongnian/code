    var myString = "Entropy";
    byte[] saltBytes = Encoding.ASCII.GetBytes("someSaltIWant");
    var dBytes = new System.Security.Cryptography.Rfc2898DeriveBytes(myString, saltBytes).GetBytes(75);
    var gibString = Convert.ToBase64String(dBytes);
    Console.WriteLine(gibString);
    // Always prints MVqAYJbmkxgQ4FdTD+a7/BlfZZLBVDXpsAAYtMuJ4aU5iejD+sB3tHqgSRoCg2KD1vnpI5eXhZa6vWvpOuM8dH8aOi1/zKMXuu4a
