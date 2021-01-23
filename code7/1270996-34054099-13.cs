    // convert to a list of rows:
    List<DataRow> query = dt.AsEnumerable().ToList();
    int sMax = (int)query.Select(x => (int)(x[1])).Max<int>();  // find the maximum value
    double[] sums = new double[sMax + 1];
    for (int i = 0; i < query.Count(); i++)      // loop over data
        {
            int val = (int)(query[i]["ttkh"]);    // get value
            sums[val] += 1;                       // count values
    }
 
