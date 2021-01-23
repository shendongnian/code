    public void Init(List<int> numbers, List<string> texts)
    {
        Func<List<int>, int> intFunc = GenGetFirst<int>();
        Func<List<string>, string> stringFunc = GenGetFirst<string>();
    
        int n = intFunc(numbers);
        string t = stringFunc(texts);
    }
