        public static int Calculate(int start, int finish, List<long> numbers)
        {
            HashSet<long> resultSet = new HashSet<long>();            
            for (int indexA = 0; indexA < numbers.Count - 1; indexA++)
            {
                for (int indexB = indexA+1; indexB < numbers.Count; indexB++)
                {
                    long tempSum = numbers[indexA] + numbers[indexB];
                    if ((tempSum >= start) && (tempSum <= finish))
                    {
                        resultSet.Add(tempSum);
                    }
                }
            }
            return resultSet.Count();
        }
