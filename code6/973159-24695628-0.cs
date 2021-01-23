    [ExcelFunction(Description = "fonction de recherche")]
    public static object id(string _isin)
    { 
        try 
        {
            double res;
            res = DBSQL.Instance.getID(_isin);
            return res; 
        }
        catch (Exception ex)
        {
            return "!!! ERROR: " + ex.ToString();
        }
    }
