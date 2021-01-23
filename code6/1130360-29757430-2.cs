    public class ListManager<T> where T : class //  T is reference type
	{
		private List<T> m_list;
        public ListManager()
        {
            m_list = new List<T>();
        }
		public List<T> Open(string filename)
        {
            BinSerializerUtility binSerial = new BinSerializerUtility();
            return binSerial.BinaryFileDeSerialize<T>(filename); // just T
        }
	}
