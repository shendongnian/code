        public static Tuple<DataTable, int> ShutterstockSearchResults(string url)
        {
            [...]
            return new Tuple<DataTable, int>(dt, totalCount);
        }
        public static void SomeConsumerMethod()
        {
            var result = ShutterstockSearchResults(myPath);
            DataTable dt = result.Item1;
            int totalCount = result.Item2;
        }
