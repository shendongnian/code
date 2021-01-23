	public class F<T> where T : class
	{
		private FileHelperEngine<T> fh = new FileHelperEngine<T>();
		public string GetObject(IEnumerable<T> obj)
		{
			return fh.WriteString(obj);
		}
	}
