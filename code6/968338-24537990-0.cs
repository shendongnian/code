    public static void TryOperation(Mutex mutex, Action action)
    {
        using (RAIIMutex raii = new RAIIMutex(mutex))
        {
            if (ShouldContinueOperation())
                action();
        }
    }
