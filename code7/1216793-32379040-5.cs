    public static class Asynchronous
    {
        public async static Task DoTheWholeThing(CancellationToken cancellationToken)
        {
            using (var a = new A())
            using (var b = new B()) {
                var taskA = a.GetStuffAsync(cancellationToken);
                var taskB = b.GetStuffAsync(cancellationToken);
                await Task.WhenAll(new [] { taskA, taskB });
                var combination = CombineStuff(taskA.Result, taskB.Result);
            }
        }
    
        private Combination CombineStuff(AStuff aStuff, BStuff bStuff)
        {
            //// Magic Here
        }
    }
