    try
    {
      correctpassword = (Console.ReadLine());
      Console.WriteLine(string.Format("UserInput: {0}", userinputpassword));
      Console.WriteLine(string.Format("correctpassword: {0}", correctpassword));
      Console.WriteLine(string.Format("passwords match: {0}", correctpassword == userinputpassword));
      if (userinputpassword == correctpassword)
        ...
