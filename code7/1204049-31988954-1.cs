    private void orderCatalog()
            {
                var tab = from TableRow tr in tabArticle.Rows
                          orderby tr.Cells[1].Text
                          select tr;
    
                List<TableRow> l = new List<TableRow>();
    
                foreach (TableRow tr in tab)
                {
                    l.Add(tr);
                }
    
                tabArticle.Rows.Clear();
    
                foreach (TableRow tr in l)
                {
                    tabArticle.Rows.Add(tr);
                }
            }
