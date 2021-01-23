        public static TestDetails RunTest(Action testMethod)
        {
            var sw = new Stopwatch();
            TimeSpan ts;
            string elapsedTime;
            sw.Start();
            testMethod.Invoke();
            sw.Stop();
            ts = sw.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            return new TestDetails("Enter username: ", "Username entered Successfully", TestDetails.Result.Pass, elapsedTime);
        }
