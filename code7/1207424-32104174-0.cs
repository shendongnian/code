    public int m_PMmonitor()
        {
            
            int count = 0,sum=0;
            int[] lm = new int[10];
            while (true)
            {
               
                try
                {
                    Process[] proc = Process.GetProcessesByName(InstanceName);
                    PerformanceCounter PC;
                    sum = proc.Count();
                    int k = 0;
                    string pname;
                    foreach (var pro in proc)
                    {
                      
                        lm[count] = pro.Id;
                        if ((sum-1) == count)
                        {
                            for (int i = 0; i <= (sum - 1); i++)
                            {
                                Process p = Process.GetProcessById(lm[i]);
                                pname = p.ProcessName;
                                if (k == 0)
                                {
                                    PC = new PerformanceCounter("Process", "Working Set - Private", pname, true);
                                    memsize = Convert.ToInt32(PC.NextValue()) / 1024;
                                    Console.WriteLine(memsize);
                                    k++;
                                }
                                else
                                {
                                    PC = new PerformanceCounter("Process", "Working Set - Private", pname + "#" + (k).ToString(), true);
                                    memsize = Convert.ToInt32(PC.NextValue()) / 1024;
                                    Console.WriteLine(memsize);
                                    k++;
                                }
                                memsize = Convert.ToInt32(PC.NextValue()) / 1024;
                            }
                        }
                        count++;
                    }
                    Thread.Sleep(800);
                    return memsize ;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    
                    Thread.Sleep(800);
                    return 0;
                }
            }
        }
 
