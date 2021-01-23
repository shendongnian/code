    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace YourCompanyName.Server.ServerCommon.Utility
    {
        /// <summary>
        /// Invoke netsh.exe and extract information from its output.
        /// Source: @crokusek, https://stackoverflow.com/questions/32196188
        ///         @GETah, https://stackoverflow.com/a/8274758/538763
        /// </summary>
        public class NetshInvoker
        {
            const string NetshHttpShowServiceStateViewRequestqArgs = "http show servicestate view=requestq";
    
            public NetshInvoker()
            {
            }
    
            /// <summary>
            /// Call netsh.exe to determine the http port number used by a given windowsPid (e.g. an IIS Express process)
            /// </summary>
            /// <param name="windowsPid">For example an IIS Express process</param>
            /// <param name="port"></param>
            /// <param name="ex"></param>
            /// <returns></returns>
            public bool TryGetHttpPortUseByProcessId(Int32 windowsPid, out List<Int32> ports, out Exception ex)
            {
                ports = null;
    
                try
                {
                    if (!TryQueryProcessIdRegisteredUrls(out Dictionary<Int32, List<string>> pidToUrlMap, out ex))
                        return false;
    
                    if (!pidToUrlMap.TryGetValue(windowsPid, out List<string> urls))
                    {
                        throw new Exception(String.Format("Unable to locate windowsPid {0} in '{1}' output.",
                            windowsPid, "netsh " + NetshHttpShowServiceStateViewRequestqArgs));
                    }
    
                    if (!urls.Any())
                    {
                        throw new Exception(String.Format("WindowsPid {0} did not reference any URLs in '{1}' output.",
                            windowsPid, "netsh " + NetshHttpShowServiceStateViewRequestqArgs));
                    }
    
                    ports = urls
                        .Select(u => new Uri(u).Port)
                        .ToList();
    
                    return true;
                }
                catch (Exception ex_)
                {
                    ex = ex_;
                    return false;
                }
            }
    
            private bool TryQueryProcessIdRegisteredUrls(out Dictionary<Int32, List<string>> pidToUrlMap, out Exception ex)
            {
                if (!TryExecNetsh(NetshHttpShowServiceStateViewRequestqArgs, out string output, out ex))
                {
                    pidToUrlMap = null;
                    return false;
                }
    
                bool gotRequestQueueName = false;
                bool gotPidStart = false;
                int currentPid = 0;
                bool gotUrlStart = false;
    
                pidToUrlMap = new Dictionary<int, List<string>>();
    
                foreach (string line in output.Split('\n').Select(s => s.Trim()))
                {
                    if (!gotRequestQueueName)
                    {
                        gotRequestQueueName = line.StartsWith("Request queue name:");
                    }
                    else if (!gotPidStart)
                    {
                        gotPidStart = line.StartsWith("Process IDs:");
                    }
                    else if (currentPid == 0)
                    {
                        Int32.TryParse(line, out currentPid);   // just get the first Pid, ignore others.
                    }
                    else if (!gotUrlStart)
                    {
                        gotUrlStart = line.StartsWith("Registered URLs:");
                    }
                    else if (line.ToLowerInvariant().StartsWith("http"))
                    {
                        if (!pidToUrlMap.TryGetValue(currentPid, out List<string> urls))
                            pidToUrlMap[currentPid] = urls = new List<string>();
    
                        urls.Add(line);
                    }
                    else // reset
                    {
                        gotRequestQueueName = false;
                        gotPidStart = false;
                        currentPid = 0;
                        gotUrlStart = false;
                    }
                }
                return true;
            }
    
            private bool TryExecNetsh(string args, out string output, out Exception exception)
            {
                output = null;
                exception = null;
    
                try
                {
                    // From @GETah, https://stackoverflow.com/a/8274758/538763
                    Process p = new Process();
                    p.StartInfo.FileName = "netsh.exe";
                    p.StartInfo.Arguments = args;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.Start();
    
                    output = p.StandardOutput.ReadToEnd();
                    return true;
                }
                catch (Exception ex)
                {
                    exception = ex;
                    return false;
                }
            }
        }
    }
