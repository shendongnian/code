    public string numColumnStr = "";
            numColumnStr = parameters.columns;
            int numColumns = 2;
            if (!string.IsNullOrEmpty(numColumnStr))
                int.TryParse(numColumnStr, out numColumns);
