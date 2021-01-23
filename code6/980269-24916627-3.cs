    using System.Linq;
    
    [WebMethod]
    public static int GetSum()
    {
        int nSum = 0;
        // get a reference to the column...
        nSum = columnRef.Sum();
    
        // or get a reference to the table
        nSum = tableRef.Sum(o => o.oneOfTheColumns);
        // if the values in the column are strings representing numbers.
        nSum = tableRef.Sum(o => int.Parse(o.oneOfTheCollumns)); 
        // follow the same pattern for other number types
        return nSum;
    }
