    public struct Values
    {
        public string value1;
        ...
        public string valueN;
        public static Values Init(DataSet dataSet)
        {
            // populate values logic here (use the extension from above)
            value1 = dataSet.GetValue(1);
             ...
            valueN = dataSet.GetValue(N);
        }
    }
