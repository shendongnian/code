    Node = JSONNode.Parse(jsonFile());
    foreach (JSONNode item in Node["story"].Keys)
    {
        List<object> parameters = new List<object>();
        var method = sys.GetType().GetMethod(item.ToString().Replace("\"", ""));
        for (int i = 0; i < Node["story"][item].Count; i++)
        {
            string data = Node["story"][item][i];
            int n;
            bool isNum = int.TryParse(data, out n);
            if (isNum)
            {
                parameters.Add(n);
            }
            else
            {
                parameters.Add(data);
            }
        }
        method.Invoke(sys, parameters.ToArray());
    }
