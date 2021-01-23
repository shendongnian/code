    string output = "";
    for(int i = 1; i <= lines.Length; i++)
    {
        output+=i+"\t"+lines[i-1];
        if (i < lines.Length)
        {
            output+="\n";
        }
    }
