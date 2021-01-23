	/// <summary>
	/// Writes random data.
	/// </summary>
	public class NeverendingFile : IHttpHandler {
		public bool IsReusable {
			get { return false; }
		}
		public void ProcessRequest(HttpContext context) {
			context.Response.Buffer = false;
			context.Response.BufferOutput = false;
			context.Response.ContentType = "application/octet-stream";
			context.Response.AppendHeader("Content-Disposition", "attachment;filename=\"Neverendingfile.dat\"");
			context.Response.Flush();
			// flag used for debuging, in production it will be always false => writing into output stream will nevere ends
			var shouldStop = false;
			for(var i = 0; !shouldStop; i++) {
				// chunk contains random data
				var chunk = Guid.NewGuid().ToByteArray();
				for (var a = 0; a < 1000; a++) {
					context.Response.OutputStream.Write(chunk, 0, chunk.Length);
				}
				context.Response.OutputStream.Flush();
				// sleep is just for slowing the download
				System.Threading.Thread.Sleep(10);
				if (!context.Response.IsClientConnected) {
					// the download was canceled or broken
					return;
				}
			}
		}
	}
