    public static class XDocumentExtensions
    {
        public static bool TryLoad(string fileName, out XDocument doc)
        {
            try
            {
                doc = XDocument.Load(fileName);
                return true;
            }
            catch (FileNotFoundException)
            {
                // File does not exist yet, so we must create it.
                doc = null;
            }
            catch (Exception ex)
            {
                // Some other internal error.
                // XDocument.Load() has no documented specific exception types :(
                // http://stackoverflow.com/questions/6904907/xdocument-loadxmlreader-possible-exceptions
                // So we could either catch these or pass them upwards.
                System.Diagnostics.Debug.WriteLine(ex);
                doc = null;
            }
            return false;
        }
    }
