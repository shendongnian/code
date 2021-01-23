    public string[,] GetInterestRates()
    {
        var array  =(from ir in ctx.InterestRateSet                     
                     select new List<string>{ ir.Time.ToString() , ir.Rate.ToString()}).ToArray();
 
        return CreateRectangularArray(array);  
    }
    static T[,] CreateRectangularArray<T>(IList<T>[] arrays)
    {
        // TODO: Validation and special-casing for arrays.Count == 0
        int minorLength = arrays[0].Count();
        T[,] ret = new T[arrays.Length, minorLength];
        for (int i = 0; i < arrays.Length; i++)
        {
            var array = arrays[i];
            if (array.Count != minorLength)
            {
                throw new ArgumentException
                    ("All arrays must be the same length");
            }
            for (int j = 0; j < minorLength; j++)
            {
                ret[i, j] = array[j];
            }
        }
        return ret;
    }
