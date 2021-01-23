    class ThrottleMyFunction
    {
        private class Arguments
        {
            public int coolInt;
            public double whatever;
            public string stringyThing;
        }
        private ConcurrentQueue<Arguments> _argQueue = new ConcurrentQueue<Arguments>();
        private Task _loop;
        //If you want to do "X times per minute", replace this argument with an int and use TimeSpan.FromMinutes(1/waitBetweenCalls)
        public void ThrottleMyFunction(TimeSpan waitBetweenCalls)
        {
            _loop = Task.Factory.StartNew(() =>
            {
                Arguments args;
                while (true)
                {
                    if (_argQueue.TryDequeue(out args))
                        FunctionIWantToThrottle(args.coolInt, args.whatever, args.stringyThing);
                }
                Thread.Sleep(waitBetweenCalls);
            });
        }
        public void ThrottledFunction(int coolerInt, double whatevs, string stringy)
        {
            _argQueue.Enqueue(new Arguments() { coolInt = coolerInt, whatever = whatevs, stringyThing = stringy });
        }
    }
