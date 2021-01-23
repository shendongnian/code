    string s = "<p>Hi <<USER>>,<br/>How are you doing<br/>Regards,<br/><<SENDER>></p>";
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    dictionary.Add("<<USER>>", "Jhon");
    dictionary.Add("<<SENDER>>", "Team");
    StringBuilder text = new StringBuilder(s);
    foreach (var entry in dictionary)
    {
        text.Replace(entry.Key, entry.Value);
    }
    Console.WriteLine(text.ToString());
