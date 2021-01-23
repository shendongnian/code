    public static void CreateWordDoc(string filename)
    {
        using (var wordDocument = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document))
        {
            // Add a main document part. 
            MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
            // Create the document structure and add some text.
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());
            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text("Hello world!"));
            //the following sets the default view when loading in Word
            DocumentSettingsPart documentSettingsPart = mainPart.AddNewPart<DocumentSettingsPart>();
            Settings settings = new Settings();
            View view1 = new View() { Val = ViewValues.Web };
            settings.Append(view1);
            documentSettingsPart.Settings = settings;
            mainPart.Document.Save();
        }
    }
