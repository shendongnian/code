    public class FutureAction
    {
        public FutureAction(FutureAction action)
        {
        }
        //public static implicit operator FutureAction(Func<int> f)
        //{
        //    return new FutureAction(null);
        //}
        public static void OverloadedMethod(Func<FutureAction, FutureAction> a)
        {
        }
        public static void OverloadedMethod(Func<Func<int>, FutureAction> a)
        {
        }
        public static void UserCode()
        {
            OverloadedMethod(a => new FutureAction(a));
        }
    }
