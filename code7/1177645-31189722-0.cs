           //Get Cell Index
           int cellindex = GridView.SelectedRow.DataItemIndex;
           //Get HeaderText of that cell 
           string headerRowText = GridView.HeaderRow.Cells[cellindex].Text;
           //Loopthrough, find that header text, get column # of that col.
           foreach (DataControlField col in GridView.Columns)
           {
               if (col.HeaderText.ToLower().Trim() == headerRowText .ToLower().Trim())
               {
                   return GridView.Columns.IndexOf(col);
               }
           }
