    string input = "Tr.WH.Eu6.ISC";
    string[] splitStrings = input.Split('.');
    List<string> subs = new List<string>();
    for (int i = 1; i <= splitStrings.Count(); i++)
    {
        subs.Add(String.Join(".", splitStrings.Take(i).ToArray()));
    }
