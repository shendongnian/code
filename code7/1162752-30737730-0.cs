    public string Escape(string input)
    {
        string[] pieces = input.Split('|');
        
        for (int i = 0; i < pieces.Length; i++)
        {
            string piece = pieces[i];
            
            if (piece.StartsWith("\"") && piece.EndsWith("\""))
            {
                pieces[i] = "\"" + piece.Trim('\"').Replace("\"", "\"\"") + "\"";
            }
        }
        
        return string.Join("|", pieces);
    }
