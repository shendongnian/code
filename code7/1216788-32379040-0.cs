    public static class Asynchronous
    {
        public async static Task DoTheWholeThing(CancellationToken cancellationToken)
        {
            using (var a = new A())
            using (var b = new B()) {
                var combination = CombineStuff(
                   await a.GetStuffAsync(cancellationToken),
                   await b.GetStuffAsync(cancellationToken));
             }
        }
    
        private Combination CombineStuff(AStuff aStuff, BStuff bStuff)
        {
            //// Magic Here
        }
    }
