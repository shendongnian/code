    string User_ID = Guid.NewGuid().ToString();
    for (int i = 0; i < i; i++)
    {
    }
    
    Directory.CreateDirectory("data\\" + User_ID);
    var sw = new StreamWriter("data\\" + User_ID + "\\data.txt");
    
    sw.WriteLine(User_ID);
    sw.Close();
