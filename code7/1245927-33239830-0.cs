    class Eg
    {
        List<T> Test { get; set; }
        T GetTest()
        {
            return Test[0];
        }
        T GetTest(int index)
        {
            return Test[index];
        }
    }
