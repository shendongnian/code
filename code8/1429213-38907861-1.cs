        private static async void CallAPI1(object state)
        {
            var data = state as SomeData;
            Console.WriteLine("Calling API One to get some data.");
            data.SomeStringValue = DateTime.Now.ToString();
            //Before this will cause the program to wait
            await CallAPI2(data);
            // Now it will call and forget
            CallAPI2(data);
            _timer.Change(TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
        }
