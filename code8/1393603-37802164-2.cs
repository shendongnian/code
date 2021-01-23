            HtmlTable table = new HtmlTable();
            foreach (Orders p in lst)
            {
                var row = new HtmlTableRow();
                var td = new HtmlTableCell();
                td.InnerHtml = p.Prezzo;
                row.Cells.Add(td);
                td = new HtmlTableCell();
                td.InnerHtml = p.Dettaglio;
                row.Cells.Add(td);
                td = new HtmlTableCell();
                td.InnerHtml = p.Voto;
                row.Cells.Add(td);
                td = new HtmlTableCell();
                LinkButton btnEliminaOrdine = new LinkButton();
                btnEliminaOrdine.ID = "btnEliminaOrdine"+p.Id;
                btnEliminaOrdine.CssClass = "btn btn-danger btn-xs";
                btnEliminaOrdine.Text = "Delete";
                btnEliminaOrdine.Click += new System.EventHandler(this.btnEliminaOrdine_Click);
                td.Controls.Add(btnEliminaOrdine);
                row.Cells.Add(td);
                table.Rows.Add(row);
            }
