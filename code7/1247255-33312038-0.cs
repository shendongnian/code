	[TestMethod]
	public void Pivot_From_Table_Test()
	{
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)),new DataColumn("Col3", typeof (object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = i; row[1] = i*10; row[2] = Path.GetRandomFileName();
			datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Pivot_From_Table.xlsx");
		if (fi.Exists)
			fi.Delete();
		const string tablename = "PivotTableSource";
		using (var pck = new ExcelPackage())
		{
			var workbook = pck.Workbook;
			var source = workbook.Worksheets.Add("source");
			source.Cells.LoadFromDataTable(datatable, true);
			var datacells = source.Cells["A1:C11"];
			source.Tables.Add(datacells, tablename);
			var pivotsheet = workbook.Worksheets.Add("pivot");
			pivotsheet.PivotTables.Add(pivotsheet.Cells["A1"], datacells, "PivotTable1");
			//Copy the zip archive
			using (var orginalzip = new ZipArchive(new MemoryStream(pck.GetAsByteArray()), ZipArchiveMode.Read))
			using (var copiedzip = new ZipArchive(fi.Open(FileMode.Create, FileAccess.ReadWrite), ZipArchiveMode.Update))
			{
				//Go though each file in the zip one by one and copy over to the new file - entries need to be in order
				orginalzip.Entries.ToList().ForEach(entry =>
				{
					var newentry = copiedzip.CreateEntry(entry.FullName);
					var newstream = newentry.Open();
					var orgstream = entry.Open();
					//Copy all other files except the cache def we are after
					if (entry.Name != "pivotCacheDefinition1.xml")
					{
						orgstream.CopyTo(newstream);
					}
					else
					{
						//Load the xml document to maniulate
						var xdoc = new XmlDocument();
						xdoc.Load(orgstream);
						//Get reference to the worksheet xml for proper namespace
						var nsm = new XmlNamespaceManager(xdoc.NameTable);
						nsm.AddNamespace("default", xdoc.DocumentElement.NamespaceURI);
						//get the source
                        var worksheetSource = xdoc.SelectSingleNode("/default:pivotCacheDefinition/default:cacheSource/default:worksheetSource", nsm);
						//Clear the attributes
						var att = worksheetSource.Attributes["ref"];
						worksheetSource.Attributes.Remove(att);
						att = worksheetSource.Attributes["sheet"];
						worksheetSource.Attributes.Remove(att);
						//Create the new attribute for table
						att = xdoc.CreateAttribute("name");
						att.Value = tablename;
						worksheetSource.Attributes.Append(att);
						xdoc.Save(newstream);
					}
					orgstream.Close();
					newstream.Flush();
					newstream.Close();
				});
			}
		}
	}
