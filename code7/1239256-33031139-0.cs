        static void RemoveRepeated(ref int[] array)
        {
            HashSet<int> seen = new HashSet<int>();
            List<int> newArray = new List<int>(array.Length);
            foreach(int x in array)
            {
                if(!seen.Contains(x))
                {
                    seen.Add(x);
                    newArray.Add(x);
                }
            }
            array = newArray.ToArray();
        }
