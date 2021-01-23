	public void ProcessRequest(HttpContext context) {
		string logFilePath = "PathToLogFile";
		//Determine the file path
		string filePath = Uri.UnescapeDataString(context.Request.QueryString["file"]);
		//Determine the file name
		string fileName = Path.GetFileName(filePath);
		context.Response.Buffer = false;
		context.Response.BufferOutput = false;
		context.Response.ContentType = "application/octet-stream";
		context.Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + Path.GetFileName(filePath));
		context.Response.WriteFile(filePath);
		context.Response.Flush();
		context.Response.OutputStream.Flush();
		if (!context.Response.IsClientConnected) {
			// the download was canceled or broken
			using (var writer = new StreamWriter(logFilePath, true)) {
				if (!File.Exists(logFilePath)) {
					//Create log file if one does not exist
					File.Create(logFilePath);
				}
				else {
					writer.WriteLine("The Download was canceled");
				}
			}
			return;
		}
		context.Response.End();
	}
