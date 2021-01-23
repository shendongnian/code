                //Edge process is "recycled", therefore no new process is returned.
                Process.Start("microsoft-edge:www.mysite.com");
                //We need to find the most recent MicrosoftEdgeCP process that is active
                Process[] edgeProcessList = Process.GetProcessesByName("MicrosoftEdgeCP");
                Process newestEdgeProcess = null;
                foreach (Process theprocess in edgeProcessList)
                {
                    if (newestEdgeProcess == null || theprocess.StartTime > newestEdgeProcess.StartTime)
                    {
                        newestEdgeProcess = theprocess;
                    }
                }
                newestEdgeProcess.WaitForExit();
