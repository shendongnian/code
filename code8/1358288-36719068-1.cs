        public class DataSizeFormatter
        {
            const int OneKb = 1024;
    
            private enum DataSizes
            {
                Kb,
                Mb,
                Gb,
                Tb
            }
    
            public string GetLargestDataSizeAndUnitOfMeasurement(ref double value, int decimalPlaces = 0)
            {
                var highestExponent = (int)(Math.Log(value, OneKb));        // Get the highest power which you could assign to 1024 that would not be greater than the given value.
                var lengthOfDataSizeEnum = Enum.GetNames(typeof(DataSizes)).Length;     //Get the length of the enum list
    
                int highestExponentWithLimit = highestExponent < (lengthOfDataSizeEnum - 1) ? highestExponent : lengthOfDataSizeEnum - 1;   //If the given value could be divided by a higher data unit than in your enum list then only use your highest data size unit.
    
                value = Math.Round(value / Math.Pow(OneKb, highestExponentWithLimit), decimalPlaces);   //round of your given value to the approriate data size.
    
                return ((DataSizes)highestExponentWithLimit).ToString();    //return the data size that was used to round of your given value.
    
            }
    }
