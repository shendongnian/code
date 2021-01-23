    static void Main(string[] args)
    {
        var arr = new string[2];
        Console.WriteLine("Enter the string");
        var givenstring = Console.ReadLine();
        if (givenstring != null)
        {
           int i = (givenstring.Length) / 2;
           arr[0] = givenstring.Substring(0 , i);
           arr[1] = givenstring.Substring(i, givenstring.Length - i);
        }
        Console.WriteLine("Input -> " + arr[0] + " " + arr[1]);
        var reversed = arr.Aggregate((workingSentence, next) => next + " " + workingSentence);
        Console.WriteLine("output -> " + ReverseString(reversed));
        Console.ReadLine();
    }
    static string ReverseString(string str)
    {
         char[] chars = str.ToCharArray();
         char[] result = new char[chars.Length];
         for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
         {
                result[i] = chars[j];
         }
         return new string(result);
    }
