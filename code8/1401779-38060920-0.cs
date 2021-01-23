    static void Main()
    {
        string s = "North Ridge NJ 01234";
        //Following gives {01234, NJ, Ridge, North}
        var words = s.Split(' ').ToList();
        words.Reverse();
        string zip = words[0];
        string state = words[1];
        string city = s.Replace(state + " " + zip, "");
    }
