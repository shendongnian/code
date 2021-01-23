    string[] newCredentials, data, parts;
    if (!File.Exists(@"C:\Users\Scott\Documents\dict.csv"))
    {
        //create .csv file
        newCredentials = new string[2];
        newCredentials[0] = "Bob2,password";
        newCredentials[1] = "user,pass";
        File.WriteAllLines(@"C:\Users\Scott\Documents\newdict.csv", newCredentials))
        Credentials.Add("bob2", "password");                          
        Credentials.Add("user", "pass");
    }
    else
    {
        data = File.ReadAllLines(@"C:\Users\Scott\Documents\dict.csv");
        foreach(string login in data)
        {
            parts = login.Split(',');
            Credentials.Add(parts[0].Trim(), parts[1].Trim());
        }
    }
