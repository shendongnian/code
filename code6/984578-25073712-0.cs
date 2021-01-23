        /// <summary>
        /// build thread and process list periodically and fire update event and enqueue results for the socket thread
        /// </summary>
        void usageThread()
        {
            try
            {
                int interval = 3000;
                uint start = Process.GetTickCount();
                Dictionary<uint, thread> old_thread_List;// = Process.GetThreadList();
                string exeFile = Process.exefile;
                //read all processes
                Dictionary<uint, process> ProcList = Process.getProcessNameList();
                DateTime dtCurrent = DateTime.Now;
                //######### var declarations
                Dictionary<uint, thread> new_ThreadList;
                uint duration;
                long system_total;
                long user_total, kernel_total;      //total process spend in user/kernel
                long thread_user, thread_kernel;    //times the thread spend in user/kernel
                DWORD dwProc;
                float user_percent;
                float kernel_percent;    
                ProcessStatistics.process_usage usage;
                ProcessStatistics.process_statistics stats = null;
                string sProcessName = "";
                List<thread> processThreadList = new List<thread>();
                //extended list
                List<threadStatistic> processThreadStatsList = new List<threadStatistic>(); //to store thread stats
                while (!bStopMainThread)
                {
                    eventEnableCapture.WaitOne();
                    old_thread_List = Process.GetThreadList();  //build a list of threads with user and kernel times
                    System.Threading.Thread.Sleep(interval);
                    //get a new thread list
                    new_ThreadList = Process.GetThreadList();   //build another list of threads with user and kernel times, to compare
                    duration = Process.GetTickCount() - start;
                    ProcList = Process.getProcessNameList();    //update process list
                    dtCurrent = DateTime.Now;
                    system_total = 0;
                    statisticsTimes.Clear();
                    //look thru all processes
                    foreach (KeyValuePair<uint, process> p2 in ProcList)
                    {
                        //empty the process's thread list
                        processThreadList=new List<thread>();
                        processThreadStatsList = new List<threadStatistic>();
                        user_total     = 0;  //hold sum of thread user times for a process
                        kernel_total   = 0;  //hold sum of thread kernel times for a process
                        sProcessName = p2.Value.sName;
                        //SUM over all threads with that ProcID
                        dwProc = p2.Value.dwProcID;
                        foreach (KeyValuePair<uint, thread> kpNew in new_ThreadList)
                        {
                            thread_user = 0;
                            thread_kernel = 0;
                            //if the thread belongs to the process
                            if (kpNew.Value.dwOwnerProcID == dwProc)
                            {
                                //is there an old thread entry we can use to calc?
                                thread threadOld;
                                if (old_thread_List.TryGetValue(kpNew.Value.dwThreadID, out threadOld))
                                {
                                    thread_user=Process.GetThreadTick(kpNew.Value.thread_times.user) - Process.GetThreadTick(old_thread_List[kpNew.Value.dwThreadID].thread_times.user);
                                    user_total += thread_user;
                                    thread_kernel =Process.GetThreadTick(kpNew.Value.thread_times.kernel) - Process.GetThreadTick(old_thread_List[kpNew.Value.dwThreadID].thread_times.kernel);
                                    kernel_total += thread_kernel;
                                }
                                //simple list
                                thread threadsOfProcess = new thread(kpNew.Value.dwOwnerProcID, kpNew.Value.dwThreadID, kpNew.Value.thread_times);
                                processThreadList.Add(threadsOfProcess);
                                //extended list
                                threadStatistic threadStats = 
                                    new threadStatistic(
                                        kpNew.Value.dwOwnerProcID, 
                                        kpNew.Value.dwThreadID, 
                                        new threadtimes(thread_user, thread_kernel), 
                                        duration, 
                                        dtCurrent.Ticks);
                                processThreadStatsList.Add(threadStats);
                            }//if dwProcID matches
                        }
                        //end of sum for process
                        user_percent      = (float)user_total / (float)duration * 100f;
                        kernel_percent    = (float)kernel_total / (float)duration * 100f;
                        system_total = user_total + kernel_total;
                        // update the statistics with this process' info
                        usage = new ProcessStatistics.process_usage(kernel_total, user_total);
                        // update process statistics
                        stats = new ProcessStatistics.process_statistics(p2.Value.dwProcID, p2.Value.sName, usage, dtCurrent.Ticks, duration, processThreadStatsList);
                        //add or update the proc stats
                        if (exeFile != p2.Value.sName || bIncludeMySelf)
                        {
                            statisticsTimes[p2.Value.sName] = stats;
                                procStatsQueueBytes.Enqueue(stats.ToByte());
                        }
                        start = Process.GetTickCount();
                    }//foreach process
                    onUpdateHandler(new ProcessStatsEventArgs(statisticsTimes, duration));
                    procStatsQueueBytes.Enqueue(ByteHelper.endOfTransferBytes);
                    ((AutoResetEvent)eventEnableSend).Set();
                }//while true
            }
            catch (ThreadAbortException ex)
            {
                System.Diagnostics.Debug.WriteLine("ThreadAbortException: usageThread(): " + ex.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: usageThread(): " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("Thread ENDED");
        }
