    void status()
    {
        // will be used to explicitly call the garbage collector
        const int COLLECT_EVERY_X_ITERATION = 10;
        // store the current loop number
        int currentIterationCount = 0;
        do
        {
            // increase current iteration count
            currentIterationCount++;
            using (Process test1 = new Process())
            {
                test1.StartInfo.FileName = "doSomething"; // doSomething is executable
                test1.StartInfo.UseShellExecute = false;
                test1.StartInfo.CreateNoWindow = true;
                test1.StartInfo.RedirectStandardOutput = true;
                test1.StartInfo.RedirectStandardError = true;
                test1.Start();
                string output = test1.StandardOutput.ReadToEnd();
                test1.WaitForExit();
                if (Regex.IsMatch(output, "DEVICE_READY", RegexOptions.IgnoreCase))
                {
                    pictureBox2.BackColor = Color.Green;
                }
                else
                {
                    pictureBox2.BackColor = Color.Yellow;
                }
            }
            // Explicitly call garbage collection every 10 iterations
            if (currentIterationCount % COLLECT_EVERY_X_ITERATION == 0)
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        } while (true);
    }
