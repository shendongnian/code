    while (true)
                {
                    Console.Clear();
                    //Every 1 Second Prints CPU Load
                      
                    //Gets current Perf Values
                    int currentCpuPercentage = (int)perfCpuCount.NextValue();
                    int currentAvailableMemory = (int)perfMemCount.NextValue();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("CPU Load        : {0}%", currentCpuPercentage);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Available Memory: {0}MB", currentAvailableMemory);
    
    
                    if (currentCpuPercentage > 80)
                    {
                        if (currentCpuPercentage == 100)
                        {
                            string cpuLoadVocalMessage = cpumaxedOutMessages[rand.Next(5)];
                            Speak(cpuLoadVocalMessage, VoiceGender.Male, speechSpeed);
                        }
                        else
                        {
    
                            string cpuLoadVocalMessage = String.Format("The current Cpu Load is {0} Percent", currentCpuPercentage);
                            Speak(cpuLoadVocalMessage, VoiceGender.Female, 3);
                        }
    
                        //Memory
    
                        if (currentAvailableMemory > 1024)
                        {
                            string memAvailableVocalMessage = String.Format("You currently have {0} Megabytes of memory available", currentAvailableMemory);
                            Speak(memAvailableVocalMessage, VoiceGender.Male, 5);
                        }
    
    
    
                      
    
                    } //End of loop
                    Thread.Sleep(1000); //note that the sleep now gets called every update cycle
                }
