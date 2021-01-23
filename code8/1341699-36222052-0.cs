    var timer = System.Diagnostics.Stopwatch.StartNew();
            timer.Start();
            while(timer.ElapsedMilliseconds < 3000)
            {
                DoWork();
            }
