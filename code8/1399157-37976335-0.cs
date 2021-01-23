			var sortedItems = sortedItems.OrderBy(m => m.Name).ToList();
            for (int i = 0; i < sortedItems.Count; i++)
            {
                r = new HtmlTableRow();
                if (i % 2 == 1)
                    r.BgColor = "#A9D0F5";
                c = new HtmlTableCell();
                LinkButton lnk = null;
                c.VAlign = "Top";
                c.Align = "Left";
                c.Width = "200px";
                c.InnerHtml = sortedItems[i].Name;
                r.Cells.Add(c);
                c = new HtmlTableCell();
                c.VAlign = "Top";
                c.Align = "Left";
                c.Width = "180px";
                c.InnerHtml = sortedItems[i].UserID;
                r.Cells.Add(c);
                c = new HtmlTableCell();
                c.VAlign = "Top";
                c.Align = "Left";
                c.Width = "800px";
                c.InnerHtml = StripOUGarbage(sortedItems[i].OU);
                r.Cells.Add(c);
                c = new HtmlTableCell();
                c.VAlign = "Top";
                c.Align = "Left";
                c.Width = "280px";
                c.InnerHtml = sortedItems[i].AccountCreateDate.ToString();
                r.Cells.Add(c);
                c = new HtmlTableCell();
                c.VAlign = "Top";
                c.Align = "Left";
                lnk = new LinkButton();
                lnk.Text = "Edit";
                lnk.ToolTip = "Edit " + sortedItems[i].Name;
                lnk.ID = i.ToString() + "_" + sortedItems[i].Name;
                lnk.Click += lnk_Click;
                lnk.OnClientClick = "ShowProgress();";
                c.Controls.Add(lnk);
                r.Cells.Add(c);
                tblItems.Rows.Add(r);
            }
