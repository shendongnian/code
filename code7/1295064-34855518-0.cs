        public static void Add(this List<int> list, int value, int otherValue)
        {
            if ((long)value + otherValue > int.MaxValue || 
                (long)value + otherValue < int.MinValue)
            {
                throw new ArgumentOutOfRangeException("Integer overflow");
            }
            else
            {
                list.Add(value + otherValue);
            }
        }
