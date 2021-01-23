    protected internal override void DeserializeElement(XmlReader reader, bool serializeCollectionKey) 
    {
        string ElementName = reader.Name;
     
        base.DeserializeElement(reader, serializeCollectionKey);
        if ((File != null) && (File.Length > 0)) {
            string sourceFileFullPath;
            string configFileDirectory;
            string configFile;
     
            // Determine file location
            configFile = ElementInformation.Source;
     
            if (String.IsNullOrEmpty(configFile)) {
                sourceFileFullPath = File;
            }
            else {
                configFileDirectory = System.IO.Path.GetDirectoryName(configFile);
                sourceFileFullPath = System.IO.Path.Combine(configFileDirectory, File);
            }
     
            if (System.IO.File.Exists(sourceFileFullPath)) {
                int lineOffset = 0;
                string rawXml = null;
     
                using (Stream sourceFileStream = new FileStream(sourceFileFullPath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    using (XmlUtil xmlUtil = new XmlUtil(sourceFileStream, sourceFileFullPath, true)) {
                        if (xmlUtil.Reader.Name != ElementName) {
                            throw new ConfigurationErrorsException(
                                    SR.GetString(SR.Config_name_value_file_section_file_invalid_root, ElementName),
                                    xmlUtil);
                        }
     
                        lineOffset = xmlUtil.Reader.LineNumber;
                        rawXml = xmlUtil.CopySection();
     
                        // Detect if there is any XML left over after the section
                        while (!xmlUtil.Reader.EOF) {
                            XmlNodeType t = xmlUtil.Reader.NodeType;
                            if (t != XmlNodeType.Comment) {
                                throw new ConfigurationErrorsException(SR.GetString(SR.Config_source_file_format), xmlUtil);
                            }
     
                            xmlUtil.Reader.Read();
                        }
                    }
                }
     
                ConfigXmlReader internalReader = new ConfigXmlReader(rawXml, sourceFileFullPath, lineOffset);
                internalReader.Read();
                if (internalReader.MoveToNextAttribute()) {
                    throw new ConfigurationErrorsException(SR.GetString(SR.Config_base_unrecognized_attribute, internalReader.Name), (XmlReader)internalReader);
                }
     
                internalReader.MoveToElement();
     
                base.DeserializeElement(internalReader, serializeCollectionKey);
            }
        }
    }
