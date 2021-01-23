    List<string> ls = null;
    Stack<string> ss = null;
    if (json != null)
    {
        ls = JsonConvert.DeserializeObject<List<string>>(json);
        ls.Reverse();
        ss = new Stack<string>(ls);
    }
