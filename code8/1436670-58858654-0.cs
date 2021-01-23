    List<string> ls = null;
    Stack<string> ss = null;
    if (json != null)
    {
        ls = JsonConvert.DeserializeObject<List<string>>(json);
        ss = new Stack<string>(ls);
    }
