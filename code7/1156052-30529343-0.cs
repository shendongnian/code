	static class arraymod
    {
        public static int Mean(int[] arr)
        {
            int valuesMean = arr.Sum()/arr.Count();
            return valuesMean;
        }
		
        public static int Median(int[] arr)
        {
            int valuesMedian = (arr.Max()+ arr.Min())/2;
            return valuesMedian;
        }
    }
