    using using System.Linq;
    public static GetSum()
    {
        // get a reference to the column...
        int nSum = columnRef.Sum();
    
        // or get a reference to the table
        int nSum = tableRef.Sum(o => o.oneOfTheColumns);
        // if the values in the column are strings representing numbers.
        int nSum = tableRef.Sum(o => int.Parse(o.oneOfTheCollumns)); 
        // follow the same pattern for other number types
    }
