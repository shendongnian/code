    #region Read XML Document from file, ignore comments
    /// <summary>
    /// Read XML Document from file, ignore comments
    /// </summary>
    /// <param name="file">string</param>
    /// <returns>XmlDocument</returns>
    public static XmlDocument ReadXML(string file)
    {
        XmlReaderSettings readerSettings;
        try
        {
            // check if document exists, otherwise exit
            if (!File.Exists(file)) { return null; }
    
            // reader settings to ignore comments
            readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;
    
            // load xml document
            using (XmlReader reader = XmlReader.Create(file, readerSettings))
            {
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(reader);
                return _xmlDoc;
            }
        }
        catch { return null; }
        finally { readerSettings = null; }
    }
    #endregion
