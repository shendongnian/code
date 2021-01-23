    Parallel.ForEach(
        searches,
        new ParallelOptions { MaxDegreeOfParallelism = 10 },
        async item => {
            var watch = new Stopwatch();
            watch.Start();
            ProcessItems(item);
            watch.Stop();
            if (watch.ElapsedMilliseconds < 1000) await Task.Delay((int)(1000 - watch.ElapsedMilliseconds));
        }
    );
