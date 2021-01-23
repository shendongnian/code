    void Thread1()
    {
        while (true)
        {
            if (stopClicked)
            {
                timeLabel.Text = stopwatch.Elapsed.ToString();
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
                Console.WriteLine("Timer stopped");
                stopwatch.Stop();
                Console.WriteLine("Stopwatch stopped");
                break;
            }
            Thread.Sleep(10);
        }
    }
