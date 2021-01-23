    string exampleString = "<1>text1</1><27>text27</27><3>text3</3>";
    string[] results = exampleString.Split(new string[] { "><" }, StringSplitOptions.None);
    Regex r = new Regex(@"^<?(\d+)>([^<]+)<");
    foreach (string result in results)
    {
        Match m = r.Match(result);
        if (m.Success)
        {
            string index = m.Groups[1].Value;
            string value = m.Groups[2].Value;
        }
    }
