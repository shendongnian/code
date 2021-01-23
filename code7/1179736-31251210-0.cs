	using System;
	using System.IO;
	using System.Threading;
	using ClosedXML.Excel;
	namespace Whatever
	{
	    class Class1
	    {
	        private static readonly object lockObject = new object();
	        public static void StartThread(string ordinal, string fileName)
	        {
	            Console.WriteLine(string.Format("creating {0} file...", ordinal));
	            var wb = new XLWorkbook(fileName, XLEventTracking.Disabled);
	            try
	            {
	                using (wb)
	                using (var ms = new MemoryStream())
	                {
	                    lock (lockObject)
	                    {
	                        Console.WriteLine(string.Format("saving {0} file...", ordinal));
	                        wb.SaveAs(ms);
	                    }
	                }
	                Console.WriteLine(string.Format("{0} file saved successfully", ordinal));
	            }
	            catch (Exception ex)
	            {
	                Console.WriteLine(ex);
	            }
	        }
	        public static void Main(string[] args)
	        {
	            var thread1 = new Thread(() => StartThread("first", "a.xlsm"));
	            thread1.Start();
	            var thread2 = new Thread(() => StartThread("second", "b.xlsm"));
	            thread2.Start();
	        }
	    }
	}
