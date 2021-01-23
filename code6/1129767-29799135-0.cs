	[TestMethod]
	public void RowHeight_Test()
	{
		var inventories = new List<RowObject>();
		for (var i = 0; i < 20; i++)
		{
			inventories.Add(new RowObject
			{
				ArtistName = "DOB - " + i,
				ArtSubCategory1 = "Cat 1 - " + i,
				ArtSubCategory2 = "Cat 2 - " + i,
				ArtTechnologyCategory = "Tech Cat - " + i,
				ArtTitle = "Title - " + i,
				ArtistBirth = "DOB - " + i,
				ArtistDeath = "DOD - " + i,
				PurchaseYear = "Year Purchased - " + i,
				SKNumber = "SKU Number - " + i,
			});
		}
		string fileName = "c:/temp/temp.xlsx";
		var newFile = new FileInfo(fileName);
		if (newFile.Exists)
			newFile.Delete();
		using (ExcelPackage pack = new ExcelPackage(newFile))
		{
			ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Blad1");
			ws.PrinterSettings.PaperSize = ePaperSize.A4;
			ws.Cells["A:XFD"].Style.Font.Name = "Arial";
			ws.Cells["A:XFD"].Style.Font.Size = 10;
			ws.DefaultRowHeight = 16.5;
			ws.View.ShowGridLines = false;
			ws.Column(1).Width = ws.Column(3).Width = ws.Column(4).Width = ws.Column(6).Width = 4;
			ws.Column(2).Width = ws.Column(5).Width = 34.5;
			int sizeRowOfLabel = 10;
			int recordCount = 0;
			int labelStartIndex, rowIndex;
			labelStartIndex = rowIndex = 2;
			string column = "B";
			using (System.Drawing.Image img = System.Drawing.Image.FromFile("c:/temp/logo.png"))
			{
				foreach (RowObject rw in inventories)
				{
					if (recordCount%2 == 0)
					{
						column = "B";
						ws.Cells["A" + labelStartIndex + ":C" + labelStartIndex].Style.Border.Top.Style =ExcelBorderStyle.Dashed;
						ws.Cells["C" + labelStartIndex + ":C" + (sizeRowOfLabel + labelStartIndex - 1)].Style.Border.Right.Style = ExcelBorderStyle.Dashed;
						ws.Cells[
							"A" + (sizeRowOfLabel + labelStartIndex - 1) + ":C" +
							(sizeRowOfLabel + labelStartIndex - 1)].Style.Border.Bottom.Style =
							ExcelBorderStyle.Dashed;
						rowIndex = labelStartIndex;
						if ((sizeRowOfLabel + labelStartIndex - 1)%41 == 0)
						{
							ws.Row(sizeRowOfLabel + labelStartIndex - 1).PageBreak = true;
						}
					}
					else
					{
						column = "E";
						ws.Cells["D" + labelStartIndex + ":F" + labelStartIndex].Style.Border.Top.Style =ExcelBorderStyle.Dashed;
						ws.Cells["F" + labelStartIndex + ":F" + (sizeRowOfLabel + labelStartIndex - 1)].Style.Border.Right.Style = ExcelBorderStyle.Dashed;
						ws.Cells["D" + (sizeRowOfLabel + labelStartIndex - 1) + ":F" +(sizeRowOfLabel + labelStartIndex - 1)].Style.Border.Bottom.Style =ExcelBorderStyle.Dashed;
						rowIndex = labelStartIndex;
						labelStartIndex += sizeRowOfLabel;
					}
					//blank
					rowIndex++;
					ws.Cells[column + rowIndex].Style.Font.Bold = true;
					//Artist
					ws.Cells[column + rowIndex].Value = rw.ArtistName.Trim() == "," ? "" : rw.ArtistName;
					rowIndex++;
					//Artist year (f. BirthYear) OR (BirthYear - DeathYear)
					string artistBirth = string.Empty;
					if (string.IsNullOrEmpty(rw.ArtistDeath))
						artistBirth = (string.IsNullOrEmpty(rw.ArtistBirth) ? "" : "f. " + rw.ArtistBirth);
					else
						artistBirth = rw.ArtistBirth + " - " + rw.ArtistDeath;
					ws.Cells[column + rowIndex].Value = artistBirth;
					rowIndex++;
					//blank
					rowIndex++;
					//Art title
					ws.Cells[column + rowIndex + ":" + column + (rowIndex + 1)].Merge = true;
					ws.Cells[column + rowIndex].Style.Font.Bold = true;
					ws.Cells[column + rowIndex].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
					ws.Cells[column + rowIndex].Style.WrapText = true;
					ws.Cells[column + rowIndex].Value = rw.ArtTitle +
														(string.IsNullOrEmpty(rw.PurchaseYear)
															? ""
															: ", " + rw.PurchaseYear);
					rowIndex++;
					//blank
					rowIndex++;
					//Category
					string category = string.Empty;
					if (!string.IsNullOrEmpty(rw.ArtTechnologyCategory))
					{
						category = rw.ArtTechnologyCategory;
						category += (string.IsNullOrEmpty(rw.ArtSubCategory1)) ? "" : ", " + rw.ArtSubCategory1;
						category += (string.IsNullOrEmpty(rw.ArtSubCategory2)) ? "" : ", " + rw.ArtSubCategory2;
					}
					else
					{
						category = (string.IsNullOrEmpty(rw.ArtSubCategory1)) ? "" : rw.ArtSubCategory1;
						category += (string.IsNullOrEmpty(rw.ArtSubCategory2)) ? "" : ", " + rw.ArtSubCategory2;
					}
					ws.Cells[column + rowIndex].Value = category;
					rowIndex++;
					//SK Number
					ws.Cells[column + rowIndex + ":" + column + (rowIndex + 1)].Merge = true;
					ws.Cells[column + rowIndex].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
					ws.Cells[column + rowIndex].Value = rw.SKNumber; //rowIndex++;
					//Logo
					//ws.Cells[column + rowIndex + ":" + column + (rowIndex + 1)].Merge = true;
					ExcelPicture pic = ws.Drawings.AddPicture(rw.SKNumber, img);
					pic.From.Column = column == "B" ? 1 : 4;
					pic.From.Row = rowIndex - 1;
					pic.From.ColumnOff = 160*9525;
					pic.From.RowOff = 4*9525;
					pic.SetSize(img.Width, img.Height);
					recordCount++;
				}
			}
			for (var i = 1; i <= 110; i++)
			{
				ws.Row(i).Height = 20;
			}
			pack.Save();
		}
	}
