    for (int i = 0; i < tsk.Length; i++)
    {
        int localI = i;
        tsk[localI] = Task.Factory.StartNew((object obj) =>
        {
             System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
             HttpWebResponse response = (HttpWebResponse)request.GetResponse();
             watch.Stop();
        }, localI);
    }
