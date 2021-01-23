            Dictionary<string, string> secondsDictionary = new Dictionary<string, string>();
            secondsDictionary.Add("Every Thirty Minutes", "1800");
            secondsDictionary.Add("Every Hour", "3600");
            secondsDictionary.Add("Every Three Hours", "10800");
            secondsDictionary.Add("Every Day", "86400");
    
    var itemlist = new SelectList(secondsDictionary, "Key" , "Value", 3600);
