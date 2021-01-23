    byte[] original = File.ReadAllBytes(@"c:\Some\Photo.jpg");
    byte[] ReturnImage = reader["Photo"] as byte[];
    if(Convert.ToBase64String(original) == Convert.ToBase64String(ReturnImage)) {
        Console.WriteLine("Success; the contents match");
    } else {
        Console.WriteLine("Failure; the contents are different");
    }
