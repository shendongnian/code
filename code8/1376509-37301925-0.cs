        {
            Word.Document oWordDoc = Globals.ThisAddIn.Application.ActiveDocument;
            Excel.Workbook oOLE = null;
            Excel.Worksheet oSheet = null;
            Word.InlineShapes ils = oWordDoc.InlineShapes;
            ils[1].OLEFormat.Activate();
            oOLE = ils[1].OLEFormat.Object;
            oSheet = oOLE.Worksheets[1];
            oSheet.get_Range("A1").Value = "I did it too!";
        }
