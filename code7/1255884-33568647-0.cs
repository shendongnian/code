    string bigdata =
        @"blablablabla@User;\u0004User\username,blablablablablablablabla@User;\u0004User\anotherusername,@Viewblablablablablablablabla";
    string searchValue = @"u0004User\";
    int index = 0;
    List<string> names = new List<string>();
    while (index < bigdata.Length)
    {
        index = bigdata.IndexOf(searchValue, index);
        if (index == -1) break;
        int start = index + searchValue.Length;
        int end = bigdata.IndexOf(',', start);
        if (end == -1) break;
        names.Add(bigdata.Substring(start, end - start));
        index = end + 1;
    }
    Console.WriteLine(string.Join(", ", names));
