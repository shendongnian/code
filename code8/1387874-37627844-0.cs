    string getpassword;
    string getusername;
    string[] text2;
    foreach (string line in File.ReadLines(@"C:\Users\Mikael2\Desktop\skypebomb\file.txt", Encoding.UTF8))
    {
        text2 = line.Split(':');
        getusername = text2[0];
        getpassword = text2[1];
        Console.WriteLine("[LOG]: Sending request from account:  {0}:{1}", getusername, string.Join("", Enumerable.Repeat("*", getpassword.Length)));
        mainSkype.Login();
    }
    new Program(new SkypeCredentials(getusername, getpassword));
