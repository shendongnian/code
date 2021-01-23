    using (var doc = WordprocessingDocument.Open(@"c:\tmp\test.docx", true))
    {
    
        var documentProtection = new DocumentProtection()
        {
            Formatting = DocumentFormat.OpenXml.OnOffValue.FromBoolean(true)
        };
    
        DocumentSettingsPart settings = doc.MainDocumentPart.DocumentSettingsPart;
    
        // instantiate our ExtendedSettings class based on the
        // original Settings
        var extset = new SettingsExt(settings.Settings.OuterXml);
    
        // new or existing?
        if (extset.DocumentProtection == null)
        {
            extset.DocumentProtection = documentProtection;
        }
        else
        {
            // replace existing values
        }
    
        // this is key to make sure our own DOMTree is saved!
        // don't forget this
        settings.Settings = extset;
    }
                
