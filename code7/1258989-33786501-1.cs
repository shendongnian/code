        public static IList<Stock> GetSome(this IList<Stock> input)
        {
            var result = new List<Stock>();
            if (input.Count < 8)
            {
                return input;
            }
            else
            {
                var i = 0;
                for (; i < input.Count; ++i)
                {
                    if (i % 8 == 0)
                    {
                        result.Add(input[i]);
                    }
                }
                if (i % 8 != 0)
                {
                    result.Add(input.Last());
                }
            }
            return result;
        }
