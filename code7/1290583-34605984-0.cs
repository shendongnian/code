        string nameValues = "|||zeeshan|1||ali|2||ahsan|3|||";
        string sub = nameValues.Substring(3, nameValues.Length - 6);
        Dictionary<string, string> dic = new Dictionary<string, string>();
        string[] subsub = sub.Split(new string[] {"||"}, StringSplitOptions.None);
        foreach (string item in subsub)
        {
            string[] nameVal = item.Split('|');
            dic.Add(nameVal[0], nameVal[1]);
        }
        foreach (var item in dic)
        {
            // Retrieve key and value here i.e:
            // item.Key
            // item.Value
        }
