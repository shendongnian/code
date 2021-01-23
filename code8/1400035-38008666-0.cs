            void Run()
        {
            int[] arr = new int[] { 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            int[] unique = arr.Distinct().ToArray();
            Dictionary<int, int> dictionary = unique.ToDictionary(k => k, v => 0);
            for(int i = 0; i < arr.Length; i++)
            {
                if(dictionary.ContainsKey(arr[i]))
                {
                    dictionary[arr[i]]++;
                }
            }
            List<KeyValuePair<int, int>> solution = dictionary.ToList();
            solution.Sort((x,y)=>-1* x.Value.CompareTo(y.Value));
            System.Console.WriteLine(solution[2].Key);
        }
