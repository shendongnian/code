    private static void QueueCheckNAdd<T>(ref T param, string input) where T : IHasSomething {
        param.DoSomethingLikeSetValue(input);
    }
    
    public interface IHasSomething {
        void DoSomethingLikeSetValue(string s);
    }
