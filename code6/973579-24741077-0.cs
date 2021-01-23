    static void Main(string[] args)
    {
        using (var document = WordprocessingDocument.Open(@"D:\DocTest\Test1.docx", true))
        {
            AddTrackingLock(document);
        }
    }
    
    private static void AddTrackingLock(WordprocessingDocument document)
    {
        var documentSettings = document.MainDocumentPart.DocumentSettingsPart;
        var documentProtection = documentSettings
                                    .Settings
                                    .FirstOrDefault(it =>
                                            it is DocumentProtection &&
                                            (it as DocumentProtection).Edit == DocumentProtectionValues.TrackedChanges)
                                    as DocumentProtection;
                                    
        if (documentProtection == null)
        {
            var documentProtectionElement = new DocumentProtection();
            documentProtectionElement.Edit = DocumentProtectionValues.TrackedChanges;
            documentProtectionElement.Enforcement = OnOffValue.FromBoolean(true);
            documentSettings.Settings.AppendChild(documentProtectionElement);
        }
        else
        {
            documentProtection.Enforcement = OnOffValue.FromBoolean(true);
        }
    }
