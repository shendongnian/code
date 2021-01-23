    Func<int> returnsIntDel = DoWorkReturnIntAsync;
    var asyncRes = returnsIntDel.BeginInvoke(null, null);
    //... some other work on main thread...
    int returnedInt = returnsIntDel.EndInvoke(asyncRes);
    Console.WriteLine("Done");
    ...
    public int DoWorkReturnIntAsync()
    {
        // This happens on a different thread.
        return 0;
    }
