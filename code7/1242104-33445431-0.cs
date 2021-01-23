     public virtual List<string> Items
     {
         get
         {
             return Rows.Select(listViewRow => listViewRow.Cells[0].Text).ToList();
         }
     }
