    for (int i = 0; i < 3; i++)
    {
        stringChars[i] = alphabetic[random.Next(alphabetic.Length)];
    }
    for(int i = 3; i< stringChars.Length; i++)
    {
        stringChars[i] = numeric[random.Next(numeric.Length)];
    }
    int n = stringChars.Length;
    while (n > 1) 
    {
        int k = random.Next(n--);
        char temp = stringChars[n];
        stringChars[n] = stringChars[k];
        stringChars[k] = temp;
    }
    string result = new string(stringChars);
