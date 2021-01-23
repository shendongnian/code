        List<string[]> objectValues = new List<string[]>
        {
           new[] { "1", "2", "3" },
           new[] { "A", "B", "C" },
        };
        string[,] prop = ConvertObjectListArray(objectValues );
        public T[,] ConvertObjectListArray<T>(IList<T[]> objectList)
        {
            int Length2 = objectList[0].Length;
            T[,] ret = new T[objectList.Count, Length2];
            for (int i = 0; i < objectList.Count; i++)
            {
                var array = objectList[i];
                if (array.Length != Length2)
                {
                    throw new ArgumentException
                        ("All arrays must be the same length");
                }
                for (int i2 = 0; i2 < Length2; i2++)
                {
                    ret[i, i2] = array[i2];
                }
            }
            return ret;
        }
