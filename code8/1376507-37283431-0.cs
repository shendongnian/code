    {
        Word.Document doc = Globals.ThisAddIn.app.ActiveDocument;
        object oRngTarget = Globals.ThisAddIn.app.Selection.Range;
        //object oRngTarget = DocumentHelper.GetBookmark("test").Range;
        object oOLEClass = "Excel.Sheet.12";
        object oFalse = false;
        Word.InlineShape ils = doc.InlineShapes.AddOLEObject(ref oOLEClass, ref missing, ref missing, 
                                   ref missing, ref missing, ref missing, ref missing, ref oRngTarget);
        Word.OLEFormat olef = ils.OLEFormat;
        System.Globalization.CultureInfo  oldCI= System.Threading.Thread.CurrentThread.CurrentCulture;
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Excel.Workbook wb = (Excel.Workbook)olef.Object;
        Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
        try
        {
            ws.get_Range("A1").Value2 = "New category";
            ws.get_Range("B1").Value2 = 6.8;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
        }
        finally
        {
            ws = null;
            wb = null;
            ils = null;
            doc = null;
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
        }
    }
