	using System;
	using System.Web;
	using System.Threading;
	public class myWebRequest:IDisposable{
		public class myEventArgs:System.EventArgs{
			public string msg;
			public myEventArgs(string s){
				msg=s;
			}
		}
		public delegate void myDelegate (myEventArgs args);
			public myDelegate theDelegate;
			void onUpdate (myEventArgs arg)
			{
				if (theDelegate != null)
					theDelegate (arg);
			}
			Thread myThread = null;
			Thread watchThread = null;
		object lockObject = new object ();
		bool bThreadRunning = false;
		public myWebRequest(){
		}
		public void Dispose(){
			if (watchThread != null) {
				watchThread.Abort ();
				watchThread = null;
			}
			if (myThread != null) {
				myThread.Abort ();
				myThread = null;
			}
		}
		public void startRequest(){
			if (myThread != null) {
				myThread.Abort ();
				myThread = null;
			}
			myThread = new Thread (theThread);
			myThread.Start ();
			//start the watch thread
			if (watchThread != null) {
				watchThread.Abort ();
				watchThread = null;
			}
			watchThread = new Thread (theWatchThread);
			watchThread.Start ();
		}
		void theWatchThread(){
			try{
				Thread.Sleep (5000);
				if (bThreadRunning && myThread != null) {
					//thread is running, try a join
					if (myThread.Join (5000)) {
						//join did work, although thread should have finished
						myThread.Abort ();
						myThread = null;
						bThreadRunning = false;
						onUpdate(new myEventArgs("failed"));
					}
				}
			}catch(ThreadAbortException ex){
			}
			catch(Exception ex){
			}
		}
		void theThread(){
			string sMsg = "";
			try {
				bThreadRunning=true;
				//call the possibly blocking function
				sMsg=myWebRequest.CallWebServiceProblem("url", 4000);
				onUpdate(new myEventArgs(sMsg));
			}catch(ThreadAbortException ex){
			
			}
			catch (Exception ex) {
				
			}
			bThreadRunning = false;
		}
		static string CallWebServiceProblem(string url, int timeout)
		{
			string s = "";
			ServicePointManager.DefaultConnectionLimit = 10;
			_logger.Trace("web service: {0} timeout: {1}", url, timeout);
			HttpWebRequest wrGETURL = null;
			try
			{
				bool isProblema = url.IndexOf("lsp_r2") >= 0;
				if (isProblema)
					_logger.Info("Sono in lsp_r2...");
				wrGETURL = (HttpWebRequest)WebRequest.Create(url);
				wrGETURL.Credentials = CredentialCache.DefaultCredentials;
				wrGETURL.ReadWriteTimeout = 10000; // Per vedere se sistema un po' i timeout...
				if (timeout != 0)
					wrGETURL.Timeout = 3000; // timeout...
				Stream ojstream = null;
				StreamReader sr = null;
				HttpWebResponse httpresponse = null;
				try
				{
					if (isProblema)
						_logger.Info("lsp_r2: Chiamo GetResponse...");
					httpresponse = (HttpWebResponse)wrGETURL.GetResponse();
					if (isProblema)
						_logger.Info("lsp_r2: Chiamo GetResponseStream...");
					ojstream = httpresponse.GetResponseStream();
					Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
					if (isProblema)
						_logger.Info("lsp_r2: Chiamo StreamReader...");
					sr = new StreamReader(ojstream, encode);
					if (isProblema)
						_logger.Info("lsp_r2: inizio a leggere");
					s = sr.ReadToEnd();
					if (isProblema)
					{
						_logger.Info("lsp_r2: terminato di leggere " + s.Length + " caratteri");
						System.Diagnostics.Debug.WriteLine("lsp_r2: terminato di leggere " + s.Length + " caratteri");
						#if DEBUG
						// _logger.Info("lsp_r2: ho letto " + s);
						System.Diagnostics.Debug.WriteLine("lsp_r2: ho letto " + s);
						#endif
					}
				}
				catch (Exception ex)
				{
					_logger.Error("web service: {0} timeout: {1} exception: {2} - {3}", url, timeout, ex.Message, ex.InnerException != null ? ex.InnerException.Message : "??");
					throw new Exception(ex.Message);
				}
				finally
				{
					if (isProblema)
						_logger.Info("lsp_r2: Concludo...");
					if (sr != null)
					{
						sr.Close();
						sr.Dispose();
					}
					if (ojstream != null)
					{
						ojstream.Close();
						ojstream.Dispose();
					}
					if (httpresponse != null)
					{
						httpresponse.Close();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
			}
			return s;
		}
	}
