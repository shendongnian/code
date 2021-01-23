     word.NormalTemplate.Saved = true;
.
     private void readWordDoc(bool reportMode, string file)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                object miss = System.Reflection.Missing.Value;
                object path = @file;
                object readOnly = true;
                Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                string totaltext = "";
                for (int i = 0; i < docs.Paragraphs.Count; i++)
                {
                    totaltext += "\n" + docs.Paragraphs[i + 1].Range.Text.ToString();
                }
                docs.Close();
                word.NormalTemplate.Saved = true;
                word.Quit();
                if (!reportMode)
                {
                    rtxtDocViewer.Text = totaltext;
                }
                
                if (reportMode)
                {
                    writeReport(totaltext, file);
                }                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error loading doc. " + ex.Message);
            }
        }
