    int imgCount = 0;
            Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = @"C:\File.docx";
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            List<string> lista = new List<string>();
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                string temp = docs.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                    lista.Add(temp);
                List<Range> ranges = new List<Range>();
                foreach (Microsoft.Office.Interop.Word.InlineShape ilshp in docs.InlineShapes)
                {
                    ilshp.Application.Selection.MoveEnd();
                    if (ilshp.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                    {
                        ranges.Add(ilshp.Range);
                        ilshp.Delete();
                        //break;
                    }
                    Microsoft.Office.Interop.Word.Paragraph prfo = docs.Paragraphs.Add(miss);
                }
                int j = 1;
                foreach (Range imgRange in ranges)
                {
                    imgRange.InsertAfter("Here was image " + j++ + ".");
                }
            }
            docs.Close(ref miss, ref miss, ref miss);
