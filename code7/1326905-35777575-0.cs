     string process = "notepad.exe";
     string sql = string.Format("select * from win32_process where name='{0}'", process);
     ManagementObjectSearcher searcher = new ManagementObjectSearcher(sql);
     StringBuilder sb = new StringBuilder();
     foreach (ManagementObject mo in searcher.Get())
     {
           string pid = mo.Properties["ProcessId"].Value.ToString();
           string cimtime = mo.Properties["CreationDate"].Value.ToString();
           cimtime = cimtime.Substring(0, cimtime.IndexOf('.'));
           string format = "yyyyMMddHHmmss";
           DateTime startTime = DateTime.ParseExact(cimtime, format, System.Globalization.CultureInfo.CurrentCulture);
           sb.AppendFormat("PID:{0}\t启动时间:{1}", pid, startTime);
           sb.AppendLine();
     }
     MessageBox.Show(sb.ToString());
