	Dictionary<string, System.Diagnostics.ProcessStartInfo> p = new Dictionary<string, System.Diagnostics.ProcessStartInfo>(); ;
	string pName = "newProcessInfo";
	for (int i = 1; i <= strings.Count(); i++)
	{
		string indexedProcess = pName + i.ToString();
		p.Add(indexedProcess, new System.Diagnostics.ProcessStartInfo());
		System.Diagnostics.ProcessStartInfo pInfo = p(indexedProcess);
		pInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
		pInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		pInfo.Verb = "runas";
		pInfo.Arguments += @"-executionpolicy unrestricted -Command " + strings[i];
		System.Diagnostics.Process.Start(pInfo);
	}
