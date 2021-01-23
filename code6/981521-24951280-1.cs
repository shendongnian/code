    public static Dictionary<string, string> GetSomeResults<T>() where T : BaseClass
    {
        if (T == typeof(Class1))
        {
            return GetSomeResults1();
        }
        else if (T == typeof(Class2))
        {
        //You got it..
        }
    }
