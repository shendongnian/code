    using using System.Linq;
    public static GetSum()
    {
        // get a reference to the column...
        int nSum = columnRef.Sum();
    
        // or get a reference to the table
        int nSum = tableRef.Sum(o => o.oneOfTheColumns);
    }
