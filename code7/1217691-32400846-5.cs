    string strEntry = "lol";
    List<int> intList = new List<int>();
    foreach (char c in strEntry)
    {
       intList.Add((int)c);
    }
    int intNum = intList.Sum();
    intNum = int.Parse(intNum.ToString().Substring(intNum.ToString().Length - 1));
