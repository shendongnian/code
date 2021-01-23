    void Main()
    {
        string firstTest = "1,2,3,"; // ends with a comma
        string secondTest = "a,b,c"; // ends with a character
        
        string[] firstArray = CreateArray(firstTest);
        PrintArray(firstArray);
        
        Console.WriteLine();
        
        string[] secondArray = CreateArray(secondTest);
        PrintArray(secondArray);
    }
    
    string[] CreateArray(string str)
    {
        string[] array = str.Split(',');
        return array.Where((s, i) =>  // return only those cells in the array where
            i < array.Length - 1 ||   // it's not the last character, or
            s != string.Empty)        // it's not empty
            .ToArray();               // in array form
    }
    
    void PrintArray(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("array[{0}] = '{1}'", i, array[i]);
        }
    }
