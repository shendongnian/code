        xl = CreateObject("Excel.Application")
        xl.Visible = False
        CopyFrom = xl.Workbooks.Open("E:\EXCEL\From.xls")
        CopyTo = xl.Workbooks.Open("E:\EXCEL\To.xls")
        For i = 0 To 1
            ''To use a password: Workbooks.Open Filename:="Filename", Password:="Password"
            If i = 0 Then
                CopyThis = CopyFrom.Sheets(1)
                CopyThis.Copy(After:=CopyTo.Sheets(CopyTo.Sheets.Count))
                CopyTo.Sheets(3).Name = "Sheet3"
            Else
                CopyThis = CopyFrom.Sheets(2)
                CopyThis.Copy(After:=CopyTo.Sheets(CopyTo.Sheets.Count))
                CopyTo.Sheets(4).Name = "Sheet4"
            End If
        Next
        CopyTo.Sheets(1).Activate()
        CopyTo.Save()
        'CopyTo.SaveAs("E:\EXCEL\Check.xls")
        xl.Quit()
