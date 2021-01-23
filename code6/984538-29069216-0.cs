    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Wordprocessing;
    using DocumentFormat.OpenXml.Packaging;
    namespace CtrlInsertMacro
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (WordprocessingDocument destDoc = WordprocessingDocument.Create("destination.docm", WordprocessingDocumentType.MacroEnabledDocument))
                {
                WordprocessingDocument srcDoc = WordprocessingDocument.Open("macrosource.docm", false);
                MainDocumentPart mainPart = destDoc.AddMainDocumentPart();
                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("This is a copied macro enabled doc. Hit Ctrl+Insert Now."));
                // Get VBA parts from source document
                VbaProjectPart vbaSrc = srcDoc.MainDocumentPart.VbaProjectPart;
                VbaDataPart vbaDatSrc = vbaSrc.VbaDataPart;
                CustomizationPart keymapSrc = srcDoc.MainDocumentPart.CustomizationPart;
                // Create VBA parts in destination document
                VbaProjectPart vbaProjectPart1 = mainPart.AddNewPart<VbaProjectPart>("rId9");
                VbaDataPart vbaDataPart1 = vbaProjectPart1.AddNewPart<VbaDataPart>("rId1");
                CustomizationPart customKeyMapPart = mainPart.AddNewPart<CustomizationPart>("rId10");
                // Copy part contents
                vbaProjectPart1.FeedData(vbaSrc.GetStream());
                vbaDataPart1.FeedData(vbaDatSrc.GetStream());
                customKeyMapPart.FeedData(keymapSrc.GetStream());
                }
            }
        }
    }
