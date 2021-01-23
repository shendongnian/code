            var ms = new MemoryStream();
            using (WordprocessingDocument myDoc = WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = myDoc.AddMainDocumentPart();
                var footPart = mainPart.AddNewPart<FootnotesPart>();
                footPart.Footnotes = new Footnotes();
                mainPart.Document = new Document();
                Body body = new Body();
                var p = new Paragraph();
                var r = new Run();
                var t = new Text("123");
                r.Append(t);
                p.Append(r);
                // ADD THE FOOTNOTE
                var footnote = new Footnote();
                footnote.Id = 1;
                var p2 = new Paragraph();
                var r2 = new Run();
                var t2 = new Text();
                t2.Text = "My FootNote Content";
                r2.Append(t2);
                p2.Append(r2);
                footnote.Append(p2);
                footPart.Footnotes.Append(footnote);
              
                // ADD THE FOOTNOTE REFERENCE
                var fref = new FootnoteReference();
                fref.Id = 1;
                var r3 = new Run();
                r3.RunProperties = new RunProperties();
                var s3 = new VerticalTextAlignment();
                s3.Val = VerticalPositionValues.Superscript;
                r3.RunProperties.Append(s3);
                r3.Append(fref);
                p.Append(r3);
                
                body.Append(p);
                mainPart.Document.Append(body);
                mainPart.Document.Save();
                ms.Flush();
            }
            return ms.ToArray();
