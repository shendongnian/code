    private string[] Load_Signal_Strength_Array(string text)
    {
        // Processing text
        var inputs = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        var outputs = new List<string>();
        foreach (string a in inputs)
        {
            // loads some stuff into the output array
            // example:
            if (!string.IsNullOrEmpty(a)) outputs.add(a);
        }
        return outputs.ToArray();
    }
