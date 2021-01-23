        public TimeSpan Duration()
        {
            return _duration = _finishTime - _startTime;
        }
        ...
        Console.WriteLine(stopwatch.Duration()); 
