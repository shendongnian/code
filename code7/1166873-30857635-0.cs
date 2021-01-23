	public class CAImportService: ICAImportService
    {
		
		// OTHER METHODS AND SECTIONS REMOVED FOR CLARITY
		
		// Define static object for the lock
		public static readonly object _lock = new object();
		
        /// <summary>
        /// Import products from tab delimited file
        /// </summary>
        /// <param name="fileName">String</param>
        public virtual void ImportProducts(string fileName, bool deleteProducts)
        {
			lock (_lock)
			{
				//Do stuff to import products
			}
        }
	}
