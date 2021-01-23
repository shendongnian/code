    string[] arr = {
                                @" CUSTOMER             PAYMENT       ERR CORR    PAYMENT AMOUNT     PAYMENT  
    REFERENCE NUMBER    INSTRUCTION TYPE   REASON*                        TYPE**",
                                                                                @"      CUSTOMER             PAYMENT       ERR CORR    PAYMENT AMOUNT     PAYMENT  
    REFERENCE NUMBER    INSTRUCTION TYPE                                  TYPE**"
                            };
    foreach (string str in arr)
    {
        List<string> list = new List<string>();
        var tmp = Regex.Split(str.Trim(), @"\s{2,}");
        list.Add(tmp[0] + " " + tmp[5]);
        list.Add(tmp[1] + " " + tmp[6]);
        if (tmp.Length == 9)
        {
            list.Add(tmp[2] + " " + tmp[7]);
        }
        else
        {
            list.Add(tmp[2]);
        }
        list.Add(tmp[3]);
        list.Add(tmp[4] + " " + tmp[tmp.Length - 1]);
        Console.WriteLine(string.Join(",", list));
    }
