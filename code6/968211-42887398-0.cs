        Dim targetFile = New IO.FileInfo(sFN)
        Dim dataSource = Enumerable.Range(0, 1).Select(Function(i) New With {.ID = 1000, .Titel = "This is a test "})
        Using epp = New OfficeOpenXml.ExcelPackage(targetFile)
            Dim ws = epp.Workbook.Worksheets.Add("lst_Anonymous")
            ws.Cells(1, 1).LoadFromCollection(dataSource, True,
                                                   OfficeOpenXml.Table.TableStyles.Medium1,
                                                   Reflection.BindingFlags.Public,
                                                   dataSource.GetType.GetGenericArguments()(1).GetProperties)
            'Why lst.GetType.GetGenericArguments()(1) "1" '''I don't no
            epp.Save()
        End Using
