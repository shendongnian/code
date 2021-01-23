            //Input events, hot observable
            var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(i => i.ToString())
                .Publish().RefCount();
           //Simulate pausing from Keyboard, not actually relevant within this answer
            var pauseObservable = Observable.FromEventPattern<KeyPressEventHandler, KeyPressEventArgs>(
                k => KeyPressed += k, k => KeyPressed -= k)
                .Select(i => i.EventArgs.PressedKey)
                .Select(i => i == ConsoleKey.Spacebar) //space is pause, others are unpause
                .DistinctUntilChanged();
            //Let events through when not paused
            var notPausedEvents = source.Zip(pauseObservable.MostRecent(false), (value, paused) => new {value, paused})
                .Where(i => !i.paused) //not paused
                .Select(i => i.value)
                .Subscribe(Console.WriteLine);
            //When paused, buffer until not paused
            var pausedEvents = pauseObservable.Where(i => i)
                .Subscribe(_ =>
                    source.BufferUntil(pauseObservable.Where(i => !i))
                        .Select(i => String.Join(Environment.NewLine, i))
                        .Subscribe(Console.WriteLine));
