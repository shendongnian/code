        public static int[][] GetChunks(int[] array, int chunkSize)
        {
            var result = new List<int[]>(array.Length / chunkSize);
            for (var i = 0; i < array.Length; i += chunkSize)
            {
                var chunk = new int[chunkSize + i < array.Length ? chunkSize : (array.Length - i - 1)];
                for (var j = 0; j < chunk.Length; j++)
                {
                    chunk[j] = array[i + j];
                }
                result.Add(chunk);
            }
            return result.ToArray();
        }
