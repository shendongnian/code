    string path = "C:\\Files\\accounts.txt";
    string[] LoginCredentials = File.ReadAllLines(path);
    for(i=0;i<LoginCredentials.Length;i++)
    {
        //Split Line (Credential[0] = Username, Credential[1] = Password)
        string[] Credential = LoginCredentials[i].Split(' ');
        //Check if input matches
        if(param1 == Credential[0] && param2 == Credential[1])
        {
           Console.WriteLine("username and password match", path); 
        }
    }
       // If Input never matched login failed
        Console.WriteLine("Login Failed: invaild username or password");
        string path2 = "C:\\Files\\audit.txt";
        using (StreamWriter sw2 = File.AppendText(path2))
        {
        sw2.WriteLine("Login Failed: Invaild username or password");
        }
        throw new FileNotFoundException();
