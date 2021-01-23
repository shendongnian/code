    public class FileParser
    {
        private Dictionary<string, Func<string, bool>> customParsingCallbacks = new Dictionary<string, Func<string, bool>>();
    
        public FileParser()
        {
            customParsingCallbacks["points"] = new Func<string, bool>((s) => { 
                                                     return geometryContentParser(s);
                                                                        }); 
        }
    
        private bool geometryContentParser(string formattedLine)
        {
            // Post: Returns True if this custom content parser is still running (needs to look at the next line) else false for completion
    
            if (formattedLine.Contains("}"))
            {
                return false;
            }
    
            return true;
        }
    }
