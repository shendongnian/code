    private void AddItem1(string res)
    {
        // Who needs validation? LIVE ON THE EDGE!
        this.CollectionList.Add(Int32.Parse(TheTextBoxValue));
        // or, if you use validation, after you successfully parse the value...
        TheTextBoxValue = null;
    }
