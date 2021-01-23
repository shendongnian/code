        static int i = 0;
        static void Main(string[] args)
        {
            using (GenerateObservableSequence().Subscribe(x => Console.WriteLine(x)))
            {
                Console.ReadLine();
            }
        }
        private static IObservable<int> GenerateObservableSequence()
        {
            var timerData = Observable.Timer(TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            var asyncCall = Observable.FromAsync<int>(() =>
            {
                TaskCompletionSource<int> t = new TaskCompletionSource<int>();
                i++;
                int k = i;
                var rndNo = new Random().Next(3, 10);
                Task.Delay(TimeSpan.FromSeconds(rndNo)).ContinueWith(r => { t.SetResult(k); });
                return t.Task;
            });
            return from t in timerData
                   from data in asyncCall
                   select data;
        }
    }
