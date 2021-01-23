            Word.Application WordApp = new Word.Application();
            d = WordApp.Documents.Open(@strFilename, ReadOnly: true, Visible: false);
            int iReplacements = 0;
            int iReplacementNoLink = 0;
            foreach (Word.Shape s in d.Shapes)
            {
                Application.DoEvents();
                try
                {
                    //if (s.Type == Microsoft.Office.Core.MsoShapeType.msoLinkedPicture)
                    if (s.LinkFormat.SourceName.ToString().Contains(".eps") || s.LinkFormat.SourceName.ToString().Contains(".png"))
                    {
                        iReplacements++;
                    }
                    s.Select();
                    if (s.AlternativeText != "" && s.AlternativeText != null)
                    {
                        iReplacementNoLink++;
                    }
                }
                catch (Exception fff)
                {
                    Console.Write(fff);
                }
            }
