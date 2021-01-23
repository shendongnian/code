                    GridViewA.DataSource = new[] { new { ColumnA = "Data 1", ColumnB = "Data 2" }, 
                                                   new { ColumnA = "Data 3", ColumnB = "Data 4" } };
                    GridViewA.DataBind();
                    GridViewB.DataSource = new[] { new { ColumnA = "Data 3", ColumnB = "Data 4" }, 
                                                   new { ColumnA = "Data 5", ColumnB = "Data 6" } };
                    GridViewB.DataBind();
                    var GridViewList = GridViewA.Rows.OfType<GridViewRow>().ToList().Select(a => new
                    {
                        ColumnA = a.Cells[0].Text,
                        ColumnB = a.Cells[1].Text
                    }).ToList();
                    GridViewList.AddRange(GridViewB.Rows.OfType<GridViewRow>().ToList().Select(a => new
                    {
                        ColumnA = a.Cells[0].Text,
                        ColumnB = a.Cells[1].Text
                    }).ToList());
                    GridViewAB.DataSource = GridViewList.Distinct().ToList();
                    GridViewAB.DataBind();
