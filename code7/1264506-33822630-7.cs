        public Dictionary<int, int> Pairs(int[] arr, int N)
        {
            // int N asssumes no arr > int32 max / 2 
            int len = arr.Length < N ? arr.Length / 2 : N / 2;
            Dictionary<int, int> d = new Dictionary<int, int>(len); 
                              // add is O(1) if count <= capacity 
            if(arr.Length == 0) return d;
            Array.Sort(arr);  // so it is O(n log n) I still take my chances with it
                              // that is n * log(n)         
            int start = 0;
            int end = arr.Length - 1;
            do
            {
                int ttl = arr[start] + arr[end];
                if (ttl == N)
                {
                    d.Add(arr[start], arr[end]); 
                          // if start <= end then pair uniquely defined by either 
                          // and a perfect hash (zero collisions)
                    start++;
                    end--;
                }
                else if (ttl > N)
                    end--;
                else
                    start++;
                if(start >= end)
                    return d;
            }   while (true);
        }
