        public IEnumerable<FileClass> GetFileClasses(string strFileName, int nCleanUpEvery = 1000)
        {
            using(var reader = File.OpenText(strFileName))
            {
	            int nParsed = 1; // Counter used to garbage collect
	            string strLine;
                while ((strLine = reader.ReadLine()) != null)  // Parse every line
	            {
                    string[] linepart = strLine.Split('\t');
                    yield return new FileClass()
		            {
			            Field1 = linepart[0],
			            Field2 = linepart[1],
			            Field3 = linepart[2]
		            };
		            // Increment the number of lines parsed and For each nCleanUpEvery lines we garbage collect
                    if (++nParsed % nCleanUpEvery == 0) 
		            {
			            GC.WaitForPendingFinalizers();
			            GC.Collect();
			            nParsed = 1; // Reset the counter
		            }	
	            }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<FileClass> fileClass = GetFileClasses("c:\\somewhere\\My19000KBFile.txt") ; 
   
            }
        }
