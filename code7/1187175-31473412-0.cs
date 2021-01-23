    class Program
        {
    
            // this program will work only if you have distinct elements in your array
    
            static void Main(string[] args)
            {
                string[] test = new string[5];
                for (int x = 0; x <= test.Length - 1; x++)
                {
                    test[x] = "#" + (x + 1) + " element";
                    Console.WriteLine(test[x]);
    
                }
                Console.ReadKey();
                Program p = new Program();
                test = p.DeleteKey(test, "#3 element"); // pass the array and record to be deleted
                for (int x = 0; x <= test.Length - 1; x++)
                {
                    Console.WriteLine(test[x]);
                }
                Console.ReadKey();
            }
    
            public string[] DeleteKey(string[] arr, string str)
            {
                int keyIndex = 0;
                if (arr.Contains(str))
                {
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] == str)
                        {
                            keyIndex = i; // get the index position of string key
                            break; // break if index found, no need to search items for further
                        }
                    }
    
                    for (int i = keyIndex; i <= arr.Length - 2; i++)
                    {
                        arr[i] = arr[i+1]; // swap next elements till end of the array
                    }
                    arr[arr.Length - 1] = null; // set last element to null
    
                    return arr; // return array
                }
                else
                {
                    return null;
                }
            }
        }
