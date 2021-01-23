    private bool ParseText(TextBox txt, List<int> theList)
    {
        int value;
        if(Int32.TryParse(txt.Text, out value))
        {
            if(value >= 100 && value <= 2000)
            {
                theList.Add(value);
                return true;
            }
         }
        return false;
    } 
