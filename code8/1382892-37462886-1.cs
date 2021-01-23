    var splitString = ang
        .Trim()
        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
    
    for(int i = 0; i < 3; i++)
    {
        this.ang[i] = Convert.ToDouble(splitString[i]);
    }
