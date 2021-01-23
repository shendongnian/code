    public void SaveData(Form form)
    {
        var data = form.Controlls
                       .OfType<TextBox>()
                       .ToDictionary(tb => tb.Name, tb => tb.Text);
        SaveToFile(data);
    }
    public void LoadData(Dictionary<string,string> data, Form form)
    {
        var boxes = form.Controlls
                        .OfType<TextBox>()
                        .ToDictionary(tb => tb.Name);
       
        foreach(var kvp in data)
        {
            boxes[kvp.key].Text = kvp.Value;
        }
    }
