    public static class Asynchronous
    {
        public async static Task DoTheWholeThing(CancellationToken cancellationToken)
        {
            Task taskA;
            Task taskB;
            using (var a = new A())
            using (var b = new B()) {
               taskA = a.GetStuffAsync(cancellationToken);
               taskB = b.GetStuffAsync(cancellationToken);
               await Task.WhenAll(new [] { taskA, taskB });
             }
             var combination = CombineStuff(taskA.Result, taskB.Result);
        }
    
        private Combination CombineStuff(AStuff aStuff, BStuff bStuff)
        {
            //// Magic Here
        }
    }
