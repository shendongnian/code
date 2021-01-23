     string sample = "ABC";
                List<string> permutations = new List<string>();
                GenerateHeapPermutations(3, ref sample, permutations);
    
                foreach (var p in permutations)
                {
                    System.Console.WriteLine(p);
                }
    
                System.Console.ReadKey();
 
    public static void GenerateHeapPermutations(int n, ref string s, List<string> sList)
            {
                if (n == 1)
                {
                    sList.Add(s);
                }
                else
                {
                    for (int i = 0; i < n - 1; i++)
                    {
                        GenerateHeapPermutations(n - 1, ref s, sList);
    
                        if (n % 2 == 0)
                        {
                            // swap the positions of two characters
                            var charArray = s.ToCharArray();
                            var temp = charArray[i];
                            charArray[i] = charArray[n - 1];
                            charArray[n - 1] = temp;
                            s = new String(charArray);
                        }
                        else
                        {
                            var charArray = s.ToCharArray();
                            var temp = charArray[0];
                            charArray[0] = charArray[n - 1];
                            charArray[n - 1] = temp;
                            s = new String(charArray);
                        }
                    }
    
                    GenerateHeapPermutations(n - 1, ref s, sList);
                }
            }
