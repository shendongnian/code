    public String ToString()
    {
        String output = "";
        var fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields)
        {
            int count = 0;
            foreach (String value in (IEnumerable<string>) field.GetValue(this))
            {
                count++;
                output += "C" + count + ": " + value + System.Environment.NewLine;
            }
        }
        return output;
    }    
