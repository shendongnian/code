    public void Test()
    {
        AsyncCallback callback = a =>
        {
            string result = foo.EndSampleFunction(a);
            Console.WriteLine(result);
        }
        object state = null;
        foo.BeginSampleFunction(callback, state);
    }
