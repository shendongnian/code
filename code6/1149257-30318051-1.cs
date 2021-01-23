	using(DocX doc = DocX.Load(filePath))
	{
        // you can use whatever condition you would like to select the table from that table.
       // I am using the Title field value in the Table Properties wizard under Alter Text tab 
		Novacode.Table t = doc.Tables.Cast<Table>().FirstOrDefault(tbl => tbl.TableCaption == "Test");
		Row r = t.InsertRow();
		doc.SaveAs("C:\\TestDoc2.docx");
	}
