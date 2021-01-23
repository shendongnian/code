    public class PurusLotteryContext : IPurusLotteryDataContextAsync { 
        public PurusLotteryContext(string conString) : base(conString) { }
    }
    public class LotteryUnitOfWork : ILotteryUnitOfWorkAsync {
        public LotteryUnitOfWork(IPurusLotteryDataContextAsync dc) { }
    }
    public class PurusLotteryBackOfficeContext : IPurusLotteryBackOfficeDataContextAsync { 
        public PurusLotteryBackOfficeContext(string conString) : base(conString) { }
    }
    public class LotteryBackOfficeUnitOfWork : ILotteryBackOfficeUnitOfWorkAsync {
        public LotteryBackOfficeUnitOfWork(IPurusLotteryBackOfficeDataContextAsync dc) { }
    }
