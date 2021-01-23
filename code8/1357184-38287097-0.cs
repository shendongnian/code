                            try
                            {
                                int timeOut = 20000;
                                var jobInfo = jobs.ElementAt(i);                               
                                while (jobInfo.IsSpooling && timeOut > 0)
                                {
                                    Thread.Sleep(100);
                                    timeOut-=100;
                                    jobInfo.Refresh(); 
                                }                                                                                                                             var pages = Math.Max(jobInfo.NumberOfPages,jobInfo.NumberOfPagesPrinted);
}
}
