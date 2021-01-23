    string A = "1234";
    string B = "567890";
    char[] chars = new char[A.Length + B.Length];
    int charsIndex = 0;
    for (int i = 0; i < A.Length || i < B.Length; i++)
    {
        if(i < A.Length)
            chars[charsIndex++] = A[i];
        if(i < B.Length)
            chars[charsIndex++] = B[i];
    }
    string result = new string(chars);
    Console.WriteLine(result);
