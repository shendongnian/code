    int numb = int.Parse(Console.ReadLine());
    var reversedString = Convert.ToString(numb, 2).ReverseString();
    var result = Convert.ToInt32(reversedString, 2);
    ...
    public static string ReverseString(this string s)
    {
	    char[] arr = s.ToCharArray();
	    Array.Reverse(arr);
	    return new string(arr);
    }
