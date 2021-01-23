     public int m_PMmonitor()
        {
            int count = 0, sum = 0,buff=0;
            while (true)
            {
                try
                {
                    Process[] proc = Process.GetProcessesByName(InstanceName);
                    PerformanceCounter PC;
                    sum = proc.Count();
                    int k = 0;
                    foreach (var pro in proc)
                    {
                                if (k == 0)
                                {
                                    PC = new PerformanceCounter("Process", "Working Set - Private", InstanceName, true);
                                }
                                else
                                {
                                    PC = new PerformanceCounter("Process", "Working Set - Private", InstanceName + "#" + (k).ToString(), true);
                                }
                                memsize = Convert.ToInt32(PC.NextValue()) / 1024;
                                Console.WriteLine(memsize);
                                buff = buff + memsize; //adding memsize of current running instance
                                PC.Dispose();
                                PC.Close();
                                count++;
                                k++;
                    }
                    Thread.Sleep(800);
                    return buff;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(800);
                    return 0;
                }
                }
            }
