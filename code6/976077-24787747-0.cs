		protected void OnbtnSaveExcelFileClick(object sender, EventArgs e)
		{
			try
			{
				using (var package = new ExcelPackage(flUploadLink.FileContent))
				{
					
					var worksheet = package.Workbook.Worksheets.Add("Games to Date - " + DateTime.Now.ToShortDateString());
					worksheet.DefaultRowHeight = 22;
					var headers = new[] { Constants.GameTitle, Constants.GameGenre, Constants.Price, Constants.Quantity };
					for (var i = 1; i < headers.Count() + 1; i++)
						worksheet.Cells[1, i].Value = headers[i - 1];
					int rowNumber = 2;
					foreach (GridViewRow row in grdGamingTable.Rows)
					{
						var index = row.RowIndex; 
						worksheet.Cells[rowNumber, 1].Value = grdGamingTable.Rows[index].Cells[2].Text;
						worksheet.Cells[rowNumber, 2].Value = grdGamingTable.Rows[index].Cells[3].Text;
						worksheet.Cells[rowNumber, 3].Value = Convert.ToInt16(grdGamingTable.Rows[index].Cells[4].Text);
						worksheet.Cells[rowNumber, 4].Value = Convert.ToInt16(grdGamingTable.Rows[index].Cells[5].Text);
						rowNumber++;
					}
					for (var i = 1; i < worksheet.Dimension.End.Column; i++)
						worksheet.Column(i).AutoFit();
					package.Workbook.Properties.Title = "Games on Record";
					package.Save();
					litExcelError.Visible = false;
					Response.Clear();
					Response.AddHeader("content-disposition", "attachment;  filename=GameRecords.xlsx");
					Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					Response.BinaryWrite(package.GetAsByteArray());
					Response.End();
				}
			}
			catch (IOException)
			{ litExcelError.Text = "Please close the file to make modifications"; }
		}
