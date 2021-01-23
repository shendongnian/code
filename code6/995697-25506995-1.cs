    public bool IsDocumentInfoExists(XbrlDocument xbrlDoc)
        {
            
            foreach (var currentFragment in xbrlDoc.XbrlFragments)
            {
                foreach (var cnodes in currentFragment.XbrlRootNode.ChildNodes)
                {
                    if (!cnodes.GetType().Name.Contains("XmlComment"))
                    {
                        var glcorAccountingEntries = ((XmlElement)(cnodes));
                        if (glcorAccountingEntries.Name.Equals("gl-cor:accountingEntries"))
                        {
                            foreach (var glcorAccountingEntry in glcorAccountingEntries)
                            {
                                if (!glcorAccountingEntry.GetType().Name.Contains("XmlComment"))
                                {
                                    var documentInfo = ((XmlElement)(glcorAccountingEntry));
                                    if (documentInfo.Name.Equals("gl-cor:documentInfo"))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
