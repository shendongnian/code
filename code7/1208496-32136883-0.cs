        private void RemoveSection(DocX doc, string deleteCommand, string deleteEndCommand)
        {
            try
            {
                int deleteStart = 0;
                int deleteEnd = 0;
                //Get the array of the paragraphs containing the start and end catches
                for (int i = 0; i < doc.Paragraphs.Count; i++)
                {
                    if (doc.Paragraphs[i].Text.Contains(deleteCommand))
                        deleteStart = i;
                    if (doc.Paragraphs[i].Text.Contains(deleteEndCommand))
                        deleteEnd = i;
                }
                if (deleteStart > 0 && deleteEnd > 0)
                {
                    //delete from the paraIndex as the arrays will shift when a paragraph is moved
                    int paraIndex = deleteStart;
                    for (int i = deleteStart; i <= deleteEnd; i++)
                    {
                        doc.RemoveParagraphAt(paraIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
