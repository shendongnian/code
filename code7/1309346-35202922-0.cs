    Option Strict On
    Imports Excel = Microsoft.Office.Interop.Excel
    Imports Microsoft.Office
    Imports System.Runtime.InteropServices
    Module OpenWorkSheets4
        Public Sub OpenExcelDoFormat(
            ByVal OpenFileName As String,
            ByVal SaveFileName As String,
            ByVal SheetName As String,
            ByVal CellAddress As String,
            ByVal NewCellValue As Long)
    
            If IO.File.Exists(OpenFileName) Then
    
                Dim Proceed As Boolean = False
    
                Dim xlApp As Excel.Application = Nothing
                Dim xlWorkBooks As Excel.Workbooks = Nothing
                Dim xlWorkBook As Excel.Workbook = Nothing
                Dim xlWorkSheet As Excel.Worksheet = Nothing
                Dim xlWorkSheets As Excel.Sheets = Nothing
                Dim xlCells As Excel.Range = Nothing
    
                xlApp = New Excel.Application
                xlApp.DisplayAlerts = False
    
                xlWorkBooks = xlApp.Workbooks
                xlWorkBook = xlWorkBooks.Open(OpenFileName)
    
                xlApp.Visible = False
    
                xlWorkSheets = xlWorkBook.Sheets
    
                For x As Integer = 1 To xlWorkSheets.Count
                    xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)
                    If xlWorkSheet.Name = SheetName Then
                        Proceed = True
                        Exit For
                    End If
    
                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                    xlWorkSheet = Nothing
    
                Next
                If Proceed Then
                    xlCells = xlWorkSheet.Range(CellAddress)
                    xlCells.Select()
    
                    xlCells.NumberFormat = "0"
                    xlCells.Value = NewCellValue.ToString
    
                    Dim xlColumns As Excel.Range = Nothing
                    xlColumns = xlCells.EntireColumn
                    xlColumns.AutoFit()
                    Runtime.InteropServices.Marshal.FinalReleaseComObject(xlColumns)
                    xlColumns = Nothing
                Else
                    MessageBox.Show(SheetName & " not found.")
                End If
    
                xlWorkSheet.SaveAs(OpenFileName)
    
                xlWorkBook.Close()
                xlApp.UserControl = True
                xlApp.Quit()
    
                ReleaseComObject(xlCells)
                ReleaseComObject(xlWorkSheets)
                ReleaseComObject(xlWorkSheet)
                ReleaseComObject(xlWorkBook)
                ReleaseComObject(xlWorkBooks)
                ReleaseComObject(xlApp)
                Process.Start(OpenFileName)
            Else
                MessageBox.Show("'" & OpenFileName & "' not located. Try one of the write examples first.")
            End If
        End Sub
        Private Sub ReleaseComObject(ByVal obj As Object)
            Try
                If obj IsNot Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                End If
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            End Try
        End Sub
    End Module
