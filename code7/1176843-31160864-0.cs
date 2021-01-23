        var timer = new Stopwatch();
        timer.Start();
        var sb = new StringBuilder();
        for (int i = 1; i <= 99; i++)
        {
            if (i%2 == 1) sb.AppendLine(i.ToString());
        }
        Console.Write(sb.ToString());
        timer.Stop();
        Console.WriteLine("took {0:0.0}ms", timer.Elapsed.TotalMilliseconds);
