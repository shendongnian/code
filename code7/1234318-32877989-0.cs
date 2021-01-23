        using(ManualResetEvent alldone = new ManualResetEvent(false))
        {
        	ManualResetEvent[] handles = null;
			try
			{
				handles = new ManualResetEvent[hosts.Length];
				for (int i = 0; i < hosts.Length; i++)
					handles[i] = new ManualResetEvent(false);
				BackgroundWorker worker = new BackgroundWorker();
				worker.DoWork += (sender, args) =>
				{
					numSucceeded = 0;
					Action<int, bool> onComplete = (hostIdx, succeeded) =>
					{
						if (succeeded) Interlocked.Increment(ref numSucceeded);
						handles[hostIdx].Set();
					};
					for (int i = 0; i < hosts.Length; i++)
						SendPing(i, onComplete);
					ManualResetEvent.WaitAll(handles);
				};
				worker.RunWorkerCompleted += (sender, args) =>
				{
					Console.WriteLine("Succeeded " + numSucceeded);
					BackgroundWorker bgw = sender as BackgroundWorker;
					alldone.Set();
				};
				worker.RunWorkerAsync();
				alldone.WaitOne();
				worker.Dispose();
			}
			finally
			{
				if (handles != null)
				{
					foreach(var handle in handles)
						handle.Dispose()
				}
			}
		} // Using alldone
