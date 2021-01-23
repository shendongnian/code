    private static List<Tuple<int, String>> GetInputData (int numberOfRows)
    {
        var result = new List<Tuple<int, String>>(numberOfRows);
        var rnd = new Random();
        for (var i = 0; i < numberOfRows; i++)
        {
            // Once in 100 records we'll have not unique value
            if (result.Count > 0 && rnd.Next(100)%1 == 0)
            {
                result.Add(new Tuple<int, string>(i,  result[rnd.Next(result.Count)].Item2));
            }
            else
                result.Add(new Tuple<int, string>(i, Guid.NewGuid().ToString()));
        }
        return result;
    }
