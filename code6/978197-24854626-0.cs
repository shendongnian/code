    	Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
		Documents docs = app.Documents;
		Document doc = docs.Open("C:\\temp\\Test2.docx", ReadOnly:true);
		Table t = doc.Tables[1];
		double b1 = t.BottomPadding;
		double t1 = t.TopPadding;
		double r1 = t.RightPadding;
		double l1 = t.LeftPadding;
		Range r = t.Range;
		Cells cells = r.Cells;
		for (int i = 1; i <= cells.Count; i++) {
			Cell cell = cells[i];
			double b2 = cell.BottomPadding;
			double t2 = cell.TopPadding;
			double r2 = cell.RightPadding;
			double l2 = cell.LeftPadding;
			Range r2b = cell.Range;
			String txt = r2b.Text;
			Marshal.ReleaseComObject(cell);
			Marshal.ReleaseComObject(r2b);
		}
		doc.Close(false);
		app.Quit(false);
		Marshal.ReleaseComObject(cells);
		Marshal.ReleaseComObject(r);
		Marshal.ReleaseComObject(t);
		Marshal.ReleaseComObject(doc);
		Marshal.ReleaseComObject(docs);
		Marshal.ReleaseComObject(app);
