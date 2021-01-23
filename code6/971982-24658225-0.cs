    public string numColumnStr = "";
        numColumnStr = parameters.columns;
        int numColumns = 2;
        if (!String.IsNullOrEmpty(numColumnStr))
            numColumns = Convert.ToInt32(numColumnStr);
