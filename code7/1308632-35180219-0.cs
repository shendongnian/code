    try{
			Process process = new Process();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.FileName = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) +@"ffmpeg";
			process.StartInfo.Arguments = command;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			JSONDataObject rtnMsg = new JSONDataObject("StartConvertOK", "-1", new List<string>());
			return JsonUtility.ToJson(rtnMsg);
		}
