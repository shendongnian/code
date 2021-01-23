    foreach (BookmarkStart bookmark in mainDoc.RootElement.Descendants<BookmarkStart>().Where(b => String.Equals(b.Name, bookmarkName)))
                {
                    var parent = bookmark.Parent;
                    using (WordprocessingDocument newTemplate = WordprocessingDocument.Open(template2, false))
                    {
                        var newTemplateBody = newTemplate.MainDocumentPart.Document.Body;
                        foreach (var element in newTemplateBody.Elements().Reverse<OpenXmlElement>())
                        {
                            parent.InsertAfterSelf<OpenXmlElement>((OpenXmlElement)element.Clone());
                        }
                    }
                }
