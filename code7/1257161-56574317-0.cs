 Private Sub GetObjectsFromExcelWorksheet(ByRef listObjects As Object, '
                                             ByVal ws As Microsoft.Office.Interop.Excel.Worksheet)
        'Fancy code that gets the type of the objects passed in a list
        Dim objType = (listObjects.GetType.GetGenericArguments())(0)
        Dim headers As New List(Of String)
        Dim A1 = ws.Range("A1")
        Dim nHeaders = ws.UsedRange.Columns.Count
        For i = 0 To nHeaders - 1
            Dim header = A1.Offset(0, i).Value
            headers.Add(header)
        Next
        For i = 1 To ws.UsedRange.Rows.Count - 1
            Dim newObj = Activator.CreateInstance(objType)
            For j = 0 To nHeaders - 1
                CallByName(newObj, headers(j), CallType.Set, A1.Offset(i, j).Value)
            Next
            listObjects.Add(newObj)
        Next
    End Sub
