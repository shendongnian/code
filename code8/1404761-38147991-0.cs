    Public Function isCellPartiallyVisible(c As Range) As Boolean
        Dim lastVRow As Long
        With Application.ActiveWindow
            lastVRow = .ScrollRow + .VisibleRange.Rows.Count - 1
            isCellPartiallyVisible = c.Row = lastVRow
        End With
    End Function
We can make the last cell in the range partially visible by using Application.Goto to bring the cell to the top of the page and then paging up using ActiveWindow.LargeScroll
    Sub MakeLastCellPartiallyVisible(rCell As Range)
        Dim lastVRow As Long
        lastVRow = rCell.Row + rCell.Rows.Count - 1
        Application.Goto Reference:=Rows(lastVRow), Scroll:=True
        ActiveWindow.LargeScroll Down:=-1
    End Sub
