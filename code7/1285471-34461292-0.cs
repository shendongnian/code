    for (int i = 0; i < N; i++)
    {
        Task<double> calcA = Task.Factory.StartNew(() => { return f1(x[i] + c[i-1]); });
        Task<double> calcB = Task.Factory.StartNew(() => { return f2(x[i] + c[i-1]); });
        Task.WaitAll(calcA, calcB);
        c[i] = calcA.Result + calcB.Result;
    }
