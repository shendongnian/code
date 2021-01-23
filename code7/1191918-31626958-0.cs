    using (StreamReader reader = new StreamReader ("/sys/devices/system/cpu/cpu0/cpufreq/stats/time_in_state") {
    
                    bool done = false;
                    while (!done)
                    {
                        String line = reader.ReadLine();
                        if (null == line)
                        {
                            done = true;
                            break;
                        }
                        String[] splits = line.Split('\\', 's', '+');
                        Debug.Assert (splits.Length == 2);
                        int timeInState = Convert.ToInt32 (splits[1]);
                        if (timeInState > 0)
                        {
                            int freq = Convert.ToInt32(splits[0]) / 1000;
                            if (freq > maxFreq)
                            {
                                maxFreq = freq;
                            }
                        }
                    }
    }
