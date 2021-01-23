    String fString = "DAVCFW_ACK*DAVCFW_20_30_90*DAVCFW_15.5_20.1_35.0*DAVCFW_40_230_110*DAVCFW_END";
    ArrayList list1 = new ArrayList();
    string[] words = fString.Split('*');
    foreach (string s in words)
    {
        list1.Add(s);
    }
    
    ArrayList list2 = new ArrayList();
    foreach(string s in list1)
    {
        list2.Add(s.Substring(6));
    }
    
    ArrayList list3 = new ArrayList();
    foreach (string s in list2)
    {
        list3.Add(s.Replace("_", string.Empty));
    }
    
    foreach (string s in list3)
    {
        Console.WriteLine(s);
    }
    
    Console.WriteLine("Number of rows: {0}", list3.Count);
    for (int i = 0; i < list3.Count; i++)
    {
        Console.WriteLine("Number of characters in {0} row: {1}",i, (list3[i] as string).Length);
    }
