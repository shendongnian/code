	public class OwnNLogFactory : NLogFactory
	{
		public OwnNLogFactory(string filePath)
		{
			foreach (var dbTarget in LogManager.Configuration.AllTargets.OfType<FileTarget>().Select(aTarget => aTarget))
			{
				dbTarget.FileName = filePath;
			}
		}
	}
