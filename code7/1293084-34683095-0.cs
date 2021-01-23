            static void Main(string[] args)
            {
                string[] arr = new string[10];
    
                arr[1] = "AAA";
                string test = "111";
    
                setValues(arr, test);
    
                int exit = -1;
                while (exit < 0)
                {
    
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(arr[i]))
                        {
                            Console.WriteLine(arr[i] + test);
                        }
                    }
                }
            }
    
            private static void setValues(string[] arr, ref string test)
            {
                arr[1] = "BBB";
                test = "222";
            }
        }
