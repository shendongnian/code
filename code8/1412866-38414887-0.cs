    static void Main()
    {
        byte[] arr = new byte[] { 1, 2, 3, 4, 5 };
        ChangeTheObject(arr);
        
        foreach(byte b in arr) {
             Console.WriteLine(b);
        }
    }
    static void ChangeTheObject(byte[] arr)
    {
         arr[2] = 7;
    }
