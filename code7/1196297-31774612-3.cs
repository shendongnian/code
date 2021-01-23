        for (int i = 0; i < numRows; i++) dataFrame.Add(new MyDataRow { 
            Id = i, Value = r.NextDouble(), 
            DerivedValues = new double[tempArraySize] });
        ...
        Parallel.ForEach(dataFrame, options, dr => {
            var array = dr.DerivedValues;
            for (int j = 0; j < array.Length; j++) array[j] = Math.Pow(dr.Value, j);
            dr.DerivedValuesSum = array.Sum();
        });
