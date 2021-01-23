    Regex matchNumber = new Regex(@"\d+");
    List<string> list = new List<string>();
    list.Add("dog456789");
    list.Add("train123456");
    list.Add("park147852");
    list.Add("car236985");
    
    list.RemoveAll(str =>
    {
        int number = int.Parse(matchNumber.Match(str).Value);
        return number < 999999 && number > 100000; // if true remove
    });
