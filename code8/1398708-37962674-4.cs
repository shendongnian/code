    public static class MyClassExtensions
    {
        public static string GetSortingKey(this MyClass item)
        {
            if (item.conditionA)
            {
                return item.valueA;
            }
            else if (item.conditionB)
            {
                return item.valueB;
            }
            else if (item.conditionC)
            {
                if (item.conditionD)
                {
                    return item.valueC;
                } 
                else
                {
                    return item.valueD;
                }
            }
            else
            {
                return item.valueE;
            }
        }
    }
