    //this fun is called after click on export button for example
    public void Export(string fileName, GridView gv)
    {
    	try
    	{
    		HttpContext.Current.Response.Clear();
    		HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", String.Format("{0}.xls", fileName)));
    		HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "utf-8");
    		HttpContext.Current.Response.Buffer = true;
    		HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
    		HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
    
    		HttpContext.Current.Response.Charset = "utf-8";//"windows-1251";//
    		HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
    
    		using (StringWriter sw = new StringWriter())
    		{
    			using (HtmlTextWriter htw = new HtmlTextWriter(sw))
    			{
    				//  Create a table to contain the grid  
    				Table table = new Table(); 
    				table.Width = Unit.Percentage(100);
    				//  include the gridline settings  
    				table.GridLines = gv.GridLines;
    				//header
    				TableRow r = new TableRow();
    				TableCell cell = new TableCell()
    				{
    					ColumnSpan = 18,
    					Text = fileName,
    					BackColor = Color.LightGray,
    					HorizontalAlign = HorizontalAlign.Center
    				};
    				cell.Font.Size = new FontUnit(14);
    				r.Cells.Add(cell);
    				table.Rows.Add(r);
    
    				GridViewRow row;
    				int rowSpan = 0;
    				
    				//second row
    				row = CreateSecondHeaderRow();
    				table.Rows.AddAt(1, row);
    
    				//first row
    				row = CreateFirstHeaderRow(row, rowSpan);
    				table.Rows.AddAt(1, row);
    
    				//  add each of the data rows to the table  
    				for (int j = 0; j < gv.Rows.Count; j++)
    				{
    					//Set the default color    
    					gv.Rows[j].BackColor = System.Drawing.Color.White;
    					for (int i = 0; i < gv.Rows[j].Cells.Count; i++)
    					{
    						gv.Rows[j].Cells[i].BackColor = System.Drawing.Color.White;
    						gv.Rows[j].Cells[i].Width = gv.Columns[i].ItemStyle.Width;
    						gv.Rows[j].Cells[i].Font.Size = gv.Columns[i].ItemStyle.Font.Size;
    						gv.Rows[j].Cells[i].Font.Bold = gv.Columns[i].ItemStyle.Font.Bold;
    						gv.Rows[j].Cells[i].Font.Italic = gv.Columns[i].ItemStyle.Font.Italic;
    						//aligh
    						if (i == 0)
    						{
    							gv.Rows[j].Cells[i].Style["text-align"] = "center";
    						}
    						else
    						{
    							gv.Rows[j].Cells[i].Style["text-align"] = "right";
    						}
    						
    						//for alternate
    						if (j % 2 != 1) gv.Rows[j].Cells[i].BackColor = Color.LightSteelBlue;
    					}
    
    					table.Rows.Add(gv.Rows[j]);
    				}
    
    				table.RenderControl(htw);
    
    				//  render the htmlwriter into the response  
    				HttpContext.Current.Response.Write(sw);
    				HttpContext.Current.Response.Flush();
    				HttpContext.Current.Response.End();
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		this._hasError = true;
    		ShowError(ex);
    	}
    }
    
    private TableHeaderCell CreateHeaderCell(string text = null, int rowSpan = 0, int columnSpan = 0, Color backColor = default(Color), Color foreColor = default(Color))
    {
    	if (object.Equals(backColor, default(Color))) backColor = Color.LightGray;
    	if (object.Equals(foreColor, default(Color))) foreColor = Color.Black;
    	return new TableHeaderCell
    	{
    		RowSpan = rowSpan,
    		ColumnSpan = columnSpan,
    		Text = text,
    		BackColor = backColor
    	};
    }
    
    private GridViewRow CreateFirstHeaderRow(GridViewRow row, int rowSpan)
    {
    	row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    
    	TableHeaderCell cell = CreateHeaderCell("Surplus %");
    	row.Controls.Add(cell);
    
    	cell = CreateHeaderCell("The date", columnSpan: 2);
    	row.Controls.Add(cell);
    
    	if (this.WithQuantity)
    	{
    		cell = CreateHeaderCell("Total Quantity", 2 + rowSpan, backColor: Color.Yellow);
    		row.Controls.Add(cell);
    	}
    
    	cell = CreateHeaderCell("Total Amount", 2 + rowSpan);
    	row.Controls.Add(cell);
    
    	cell = CreateHeaderCell("Has elapsed periods from start", columnSpan: (this.WithQuantity ? (SurplusUtil.TheColumnsNumbers * 2) : SurplusUtil.TheColumnsNumbers));
    	row.Controls.Add(cell);
    
    	if (this.WithQuantity)
    	{
    		cell = CreateHeaderCell("Quantity <br style='mso-data-placement:same-cell;' /> surplus", 2 + rowSpan, backColor: Color.Yellow);
    		row.Controls.Add(cell);
    	}
    
    	cell = CreateHeaderCell("Principal <br style='mso-data-placement:same-cell;' /> surplus", 2 + rowSpan);
    	row.Controls.Add(cell);
    
    	return row;
    }
    
    private GridViewRow CreateSecondHeaderRow()
    {
    	GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    
    	TableHeaderCell cell = CreateHeaderCell("Period number", rowSpan: ((this.WithQuantity) ? 2 : 0));
    	row.Controls.Add(cell);
    
    	cell = CreateHeaderCell("from", rowSpan: ((this.WithQuantity) ? 2 : 0));
    	row.Controls.Add(cell);
    
    	cell = CreateHeaderCell("to", rowSpan: ((this.WithQuantity) ? 2 : 0));
    	row.Controls.Add(cell);
    
    	for (int i = 0; i < SurplusUtil.TheColumnsNumbers; i++)
    	{
    		cell = CreateHeaderCell(i.ToString(),
    		columnSpan: ((this.WithQuantity) ? 2 : 0),
    		backColor: System.Drawing.Color.FromArgb(198, 239, 206),
    		foreColor: System.Drawing.Color.FromArgb(0, 97, 0));
    		row.Controls.Add(cell);
    	}
    	return row;
    }
