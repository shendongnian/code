    public void Strange(string[] array)
    {
        Debug.Assert(array.Length > 1);
        for (var i = 1; i < array.Length; i++)
            foreach (var item in array.Take(i))
                Debug.WriteLine(item);
    }
