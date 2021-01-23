    static void DisposeInstance(params IDisposable [] instances)
    {
        for (int i = 0; i < instances.Length; i++)
        {
            if (instances[i] != null)
            {
                instances[i].Dispose();
                instances[i] = null;
            }
        }
    }
