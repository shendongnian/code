    NZInput NI = new NZInput();
    NZOutput NO = new NZOutput();
    NZRX NRX = new NZRX();
    var tasks = new[]{
        Task.Run(() => NRX.nzrxins()),
        Task.Run(() => NI.nzinputins()),
        Task.Run(() => NO.nzoutputins())),
    };
    Task.WaitAll(tasks);
    
    var nrxResult = tasks[0].Result;
    var niResult = tasks[1].Result;
    var noResult = tasks[2].Result;
