    Dictionary<string, DateTime> birthdays = new Dictionary<string, DateTime>;
    
    //Add values like this 
    birthdays.Add("name 1", DateTime.Parse("11.11.1988"));
    birthdays.Add("name 2", DateTime.Parse("11.12.1988"));
    ...
    //Then you could loop through all the entries
    foreach(KeyValuePair<string, DateTime> entry in birthdays)
    {
        if(entry.Value.Day == DateTime.Now.Day && entry.Value.Month == DateTime.Now.Month)
        {
            Console.WriteLine(entry.Key + " has birthday!");
        }
    }
    
