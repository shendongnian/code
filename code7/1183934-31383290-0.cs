    var result = supplierListQuery
                          .Select(x => normalize(x.SupplierName))
                          .Where(x => x.Contains(normalize(SearchKey)));
    string normalize(string inputStr)
    {
        string retVal = inputStr.Replace("&", "");
        while (retVal.IndexOf("  ") >= 0)
        {
            retVal = retVal.Replace("  ", " ");
        }
        return retVal;
    }
