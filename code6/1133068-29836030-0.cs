    public static class UselessExtensions
    {
        public static void WhenTrue(this bool evaluatedPredicate, Action whenTrue)
        {
            if (evaluatedPredicate)
                whenTrue();
        }
    }
    public static class TryingUselessExtensions
    {
        public static bool SomeBoolTest()
        {
            return true;
        }
        public static void DoIt()
        {
            SomeBoolTest().WhenTrue(() => Console.WriteLine(true));
        }
    }
