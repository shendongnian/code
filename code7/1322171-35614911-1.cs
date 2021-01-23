    public String ToString()
    {
        String output = "";
        var collections = new[] {centers, leftWingers, rightWingers, defencemen, goalies, bench};
        foreach (var field in collections)
        {
            int count = 0;
            foreach (String value in field)
            {
                count++;
                output += "C" + count + ": " + value + System.Environment.NewLine;
            }
        }
        return output;
    }    
