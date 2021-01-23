    string strEntry = "lol";
    List<int> intList = new List<int>();
    foreach (char c in strEntry)
    {
       intList.Add((int)c);
    }
    int intNum = intList.Sum();
    while (intNum.ToString().Length != 1)
    {
       intList.Clear();
       foreach (char c in intNum.ToString())
       {
           intList.Add(int.Parse(c.ToString()));
       }
       intNum = intList.Sum();
    }
    //You can just get the number you required from intNum
