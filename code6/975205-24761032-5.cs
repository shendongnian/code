    public IEnumerator<object> PrintNextNumber()
    {
        int i = 0;
        while (true)
        {
            Console.Out.WriteLine(i++);
            yield return null;
        }
    }
