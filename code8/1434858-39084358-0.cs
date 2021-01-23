        class Exercise
        {
            static void Main()
            {
                PrintArray(arr);
                // SubarrayWithSum();
    
                
                var result = GetCombination(arr);
    
                foreach(var list in result)
                {
                    var total = list.Sum();
                    if (total == sum)
                        PrintArray(list);
                }
            }
            static List<int> arr = new List<int> { 2, 1, 2, 4, 3, 5, 2, 6 };
            static int sum = 14;
    
            static List<List<int>> GetCombination(List<int> list)
            {
                var result = new List<List<int>>();
                result.Add(new List<int>());
                double count = Math.Pow(2, list.Count);
                for (int i = 1; i <= count - 1; i++)
                {
                    string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (str[j] == '1')
                        {
                            result[i - 1].Add(list[j]);
                        }
                    }
                    result.Add(new List<int>());
                }
                return result;
            }
    
            static void PrintArray(List<int> subarray)
            {
                Console.Write("{");
                for (int i = 0; i < subarray.Count; i++)
                {
                    Console.Write(subarray[i]);
                    if (i < subarray.Count - 1) Console.Write(", ");
                }
                Console.WriteLine("}");
            }
        }
