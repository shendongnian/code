    Microsoft.Office.Interop.Excel.Application excelApp = (Microsoft.Office.Interop.Excel.Application)ExcelDnaUtil.Application;
    Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.ActiveWorkbook;
    System.Collections.IEnumerator enumerator = workbook.CustomXMLParts.SelectByNamespace("http://schemas.microsoft.com/vsto/samplestest").GetEnumerator();
    enumerator.Reset();
    if (!(enumerator.MoveNext())) {
      string xmlString1 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
        "<employees xmlns=\"http://schemas.microsoft.com/vsto/samplestest\">" +
        "<employee>" +
        "<name>Surender GGG</name>" +
        "<hireDate>1999-04-01</hireDate>" +
        "<title>Manager</title>" +
        "</employee>" +
        "</employees>";
      Office.CustomXMLPart employeeXMLPart = workbook.CustomXMLParts.Add(xmlString1);
    } else {
            
      Office.CustomXMLPart a = (Office.CustomXMLPart)enumerator.Current;
      a.NamespaceManager.AddNamespace("x", "http://schemas.microsoft.com/vsto/samplestest");
               MessageBox.Show(a.SelectSingleNode("/x:employees/x:employee/x:name").Text);
      MessageBox.Show(a.XML);
    }
