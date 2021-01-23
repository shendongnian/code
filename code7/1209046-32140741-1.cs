    public class ScheduleZipper
	{
		private int _interval;
		private DateTime _lastZip;
		private string _source;
		private string _dest;
	
		public ScheduleZipper(string source, string dest, int interval)
		{
			_interval = interval;
			_lastZip = DateTime.Now.AddMilliseconds(_interval);
		}
	
		private void ZipFilesInFolder(string path, ZipFile zip)
		{
			foreach (var file in Directory.GetFiles(path))
			{
				if (DateTime.Now >= _lastZip.AddMilliseconds(_interval))
				{
					System.Threading.Thread.Sleep(_interval);
					_lastZip = DateTime.Now;
				}
				zip.AddFile(file);
			}
		
			foreach (var dir in Directory.GetDirectories(path))
			{
				ZipFilesInFolder(path, zip);
			}
		}
		
		public void Zip()
		{
			using (var zip = new ZipFile(_dest))
			{
				ZipFilesInFolder(_source, zip);
			}
		}
	}
