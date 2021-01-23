	interface parentInterface
	{
		string methodA(params object[] asd);
	}
	public class childA : parentInterface
	{
		public string methodA(params object[] p)
		{
			string a = p[0] as string;
			string b = p[1] as string;
			long d = long.Parse(p[2]);
			return string.Empty;
		}
	}
	public class childB : parentInterface
	{
		public string methodA(params object[] p)
		{
			int e = int.Parse(p[0]);
			string f = p[1] as string;
			string g = p[2] as string;
			return string.Empty;
		}
	}
