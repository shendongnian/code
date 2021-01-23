    using (FileStream fs = File.Open(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
    		using (StreamReader sr = new StreamReader(fs)) {
    			string line = sr.ReadLine();
    			string lineA = null;
    			string lineB = null;
    			while ((line != null)) {
    				// Split your line here into lineA and lineB
    				// and write using buffered writer.
    				line = sr.ReadLine();
    			}
    		}
    }
