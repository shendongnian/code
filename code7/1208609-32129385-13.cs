    public static void Main()
    {
        A<string> first = OpenAEnum<string, CString>.Level1.New();
        A<int> second = OpenAEnum<int, CInt>.Level2.New();
        A<D> third = OpenAEnum<D, C>.Level3.New();
    }
