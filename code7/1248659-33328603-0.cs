              static void Main(string[] args)
                {
                    Program a = new Program();
                    int[] arr = a.make();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.WriteLine(arr[i]);
                    }          
                    Console.ReadLine();
                }
