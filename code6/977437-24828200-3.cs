    public async Task<IEnumerable<dynamic>> GetResults(string id, int n) {
    
    	//...
    
        StreamReader sr = new StreamReader(results);
        List<string> results = new List<string>();
        while(!sr.EndOfStream) {
            string line = await sr.ReadLineAsync();
            results.Add(line);
        }
    
        return results;
    }
