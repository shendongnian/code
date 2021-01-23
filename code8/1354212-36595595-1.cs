    //first assembly
    public void Go()
    {
        if (condition)
            GoDeep();
    }
    [MethodImpl(Met‌​hodImplOptions.NoInlining)]
    private void GoDeep()
    {
        var s = new TestItem(); //at this point second assembly will be loaded 
    }
