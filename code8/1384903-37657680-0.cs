    using Syncfusion.DocIO.DLS;
    using Syncfusion.DocIO;
    using System.IO;
    namespace DocIO_MergeDocument
    {
    class Program
    {
        static void Main(string[] args)
        {
            //Boolean to indicate whether any of the input document has different odd and even headers as true
            bool isDifferentOddAndEvenPagesEnabled = false;
            // Creating a new document.
            using (WordDocument mergedDocument = new WordDocument())
            {
                //Get the files from input directory
                DirectoryInfo dirInfo = new DirectoryInfo(System.Environment.CurrentDirectory + @"\..\..\Data");
                FileInfo[] fileInfo = dirInfo.GetFiles();
                for (int i = 0; i < fileInfo.Length; i++)
                {
                    if (fileInfo[i].Extension == ".doc" || fileInfo[i].Extension == ".docx")
                    {
                        using (WordDocument sourceDocument = new WordDocument(fileInfo[i].FullName))
                        {
                            //Check whether the document has different odd and even header/footer
                            if (!isDifferentOddAndEvenPagesEnabled)
                            {
                                foreach (WSection section in sourceDocument.Sections)
                                {
                                    isDifferentOddAndEvenPagesEnabled = section.PageSetup.DifferentOddAndEvenPages;
                                    if (isDifferentOddAndEvenPagesEnabled)
                                        break;
                                }
                            }
                            //Sets the breakcode of First section of source document as NoBreak to avoid imported from a new page
                            sourceDocument.Sections[0].BreakCode = SectionBreakCode.EvenPage;
                            //Imports the contents of source document at the end of merged document
                            mergedDocument.ImportContent(sourceDocument, ImportOptions.KeepSourceFormatting);
                        }
                    }
                }
                //if any of the input document has different odd and even headers as true then
                //Copy the content of the odd header/foort and add the copied content into the even header/footer
                if (isDifferentOddAndEvenPagesEnabled)
                {
                    foreach (WSection section in mergedDocument.Sections)
                    {
                        section.PageSetup.DifferentOddAndEvenPages = true;
                        if (section.HeadersFooters.OddHeader.Count > 0 && section.HeadersFooters.EvenHeader.Count == 0)
                        {
                            for (int i = 0; i < section.HeadersFooters.OddHeader.Count; i++)
                                section.HeadersFooters.EvenHeader.ChildEntities.Add(section.HeadersFooters.OddHeader.ChildEntities[i].Clone());
                        }
                        if (section.HeadersFooters.OddFooter.Count > 0 && section.HeadersFooters.EvenFooter.Count == 0)
                        {
                            for (int i = 0; i < section.HeadersFooters.OddFooter.Count; i++)
                                section.HeadersFooters.EvenFooter.ChildEntities.Add(section.HeadersFooters.OddFooter.ChildEntities[i].Clone());
                        }
                    }
                }
                //If there is no document to merge then add empty section with empty paragraph
                if (mergedDocument.Sections.Count == 0)
                    mergedDocument.EnsureMinimal();
                //Saves the document in the given name and format
                mergedDocument.Save("result.docx", FormatType.Docx);
            }
        }
    }
    
    }
