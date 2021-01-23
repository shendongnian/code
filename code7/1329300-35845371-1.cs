        var pur = e.Query.Cast<purchase>();
        var gridViewList = (from p in pur
                  where p.InvoiceNo == txtinvoice.Text && p.InvoiceDate > dt
                  orderby p.id descending
                  select new
                  {
                      p.Amount,
                      p.category,
                      p.description,
                      p.qty,
                      Total=p.qty*p.Amount
                  }).ToList();
