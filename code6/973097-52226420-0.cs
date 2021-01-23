        public int solution(int[] array)
        {
            HashSet<int> found = new HashSet<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    found.Add(array[i]);
                }
            }
            int result = 1;
            while (found.Contains(result))
            {
                result++;
            }
            return result;
        }
