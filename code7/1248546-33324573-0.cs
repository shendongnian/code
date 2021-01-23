        private static IEnumerable<int> FindIndexesOfMax(int[] input)
        {
            int max = input.Max();
            for (int i=0; i<input.Length; i++)
            {
                if (input[i] == max)
                    yield return i;
            }
        }
