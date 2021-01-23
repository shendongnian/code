    public static Dictionary<string, Form> forms = new Dictionary<string, Form>();
    public static Form CreateWindow(string id, int width, int height, string title)
    {
        if (!forms.ContainsKey(id))
            forms.Add(id, new Form());
        forms[id].Text = title;
        forms[id].Width = width;
        forms[id].Height = height;
        return forms[id];
    }
        
