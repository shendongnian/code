    int index = test.IndexOf("%s");
    int occurance = 0;
    while (index != -1)
    {
        result.Append(test.Substring(0, index));
        result.Append(replacements[occurance]);
        test = test.Substring(index + 2);
        occurance++;
        index = test.IndexOf("%s");
    }
    Console.WriteLine(result.ToString());
