    #Region " Members Summary "
    
    ' · Public Methods
    '
    '     MoveSelectedRows(direction)
    '     MoveSelectedRows(direction, preserveCellsIndex)
    
    #End Region
    
    #Region " Option Statements "
    
    Option Strict On
    Option Explicit On
    Option Infer Off
    
    #End Region
    
    #Region " Imports "
    
    Imports System.Diagnostics
    Imports System.Runtime.CompilerServices
    Imports System.Windows.Forms
    
    #End Region
    
    ''' <summary>
    ''' Contains sofisticated extension methods for a <see cref="DataGridView"/> control.
    ''' </summary>
    ''' <remarks></remarks>
    Public Module DataGridViewExtensions
    
    #Region " Enumerations "
    
        ''' <summary>
        ''' Specifies a direction for a move operation of a rows collection.
        ''' </summary>
        Public Enum RowMoveDirection As Integer
    
            ''' <summary>
            ''' Move row up.
            ''' </summary>
            Up = 0
    
            ''' <summary>
            ''' Move row down.
            ''' </summary>
            Down = 1
    
        End Enum
    
    #End Region
    
    #Region " Public Extension Methods "
    
        ''' <summary>
        ''' Moves up or down the selected row(s) of the current <see cref="DataGridView"/>.
        ''' </summary>
        ''' <param name="sender">The <see cref="DataGridView"/>.</param>
        ''' <param name="direction">The row-move direction.</param>
        <DebuggerStepThrough>
        <Extension>
        Public Sub MoveSelectedRows(ByVal sender As DataGridView,
                                    ByVal direction As RowMoveDirection)
    
            DoRowsMove(sender, direction)
    
        End Sub
    
        ''' <summary>
        ''' Moves up or down the selected row(s) of the current <see cref="DataGridView"/>.
        ''' </summary>
        ''' <param name="sender">The <see cref="DataGridView"/>.</param>
        ''' <param name="direction">The row-move direction.</param>
        ''' <param name="preserveCellsIndex">A sequence of cell indexes to preserve its cell values when moving the row(s).</param>
        <DebuggerStepThrough>
        <Extension>
        Public Sub MoveSelectedRows(ByVal sender As DataGridView,
                                    ByVal direction As RowMoveDirection,
                                    ByVal preserveCellsIndex As IEnumerable(Of Integer))
    
            DoRowsMove(sender, direction, preserveCellsIndex)
    
        End Sub
    
    #End Region
    
    #Region " Private Methods "
    
        ''' <summary>
        ''' Moves up or down the selected row(s) of the specified <see cref="DataGridView"/>.
        ''' </summary>
        ''' <param name="dgv">The <see cref="DataGridView"/>.</param>
        ''' <param name="direction">The row-move direction.</param>
        ''' <param name="preserveCellsIndex">Optionally, a sequence of cell indexes to preserve its cell values when moving the row(s).</param>
        <DebuggerStepThrough>
        Private Sub DoRowsMove(ByVal dgv As DataGridView,
                               ByVal direction As RowMoveDirection,
                               Optional ByVal preserveCellsIndex As IEnumerable(Of Integer) = Nothing)
    
            ' Keeps tracks of a cell value to preserve, to swap them when moving rows.
            Dim oldCellValue As Object
            Dim newCellValue As Object
    
            ' Short row collection reference.
            Dim rows As DataGridViewRowCollection = dgv.Rows
    
            ' Keeps track of the current row.
            Dim curRow As DataGridViewRow
    
            ' The maximum row index.
            Dim lastRowIndex As Integer =
                If(dgv.AllowUserToAddRows,
                   rows.Count - 2,
                   rows.Count - 1)
    
            ' List of hash codes of the selected rows.
            Dim selectedRows As New List(Of Integer)
    
            ' Get the hash codes of the selected rows
            For i As Integer = 0 To (rows.Count - 1)
                If (rows(i).IsNewRow = False) AndAlso (rows(i).Selected) Then
                    selectedRows.Add(rows(i).GetHashCode)
                    rows(i).Selected = False
                End If
            Next i
    
            ' Move the selected rows up or down.
            Select Case direction
    
                Case RowMoveDirection.Up
                    For i As Integer = 0 To lastRowIndex
    
                        If Not rows(i).IsNewRow Then
    
                            If (selectedRows.Contains(rows(i).GetHashCode)) AndAlso
                               (i - 1 >= 0) AndAlso
                               (Not selectedRows.Contains(rows(i - 1).GetHashCode)) Then
    
                                curRow = rows(i)
                                rows.Remove(curRow)
                                rows.Insert(i - 1, curRow)
    
                                If preserveCellsIndex IsNot Nothing Then
    
                                    For Each cellIndex As Integer In preserveCellsIndex
                                        oldCellValue = curRow.Cells(cellIndex).Value
                                        newCellValue = rows(i).Cells(cellIndex).Value
    
                                        rows(i).Cells(cellIndex).Value = oldCellValue
                                        curRow.Cells(cellIndex).Value = newCellValue
                                    Next cellIndex
    
                                End If
    
                            End If
    
                        End If
    
                    Next i
    
                Case RowMoveDirection.Down
                    For i As Integer = lastRowIndex To 0 Step -1
    
                        If Not rows(i).IsNewRow Then
    
                            If (selectedRows.Contains(rows(i).GetHashCode)) AndAlso
                               (i + 1 <= lastRowIndex) AndAlso
                               (Not selectedRows.Contains(rows(i + 1).GetHashCode)) Then
    
                                curRow = rows(i)
                                rows.Remove(curRow)
                                rows.Insert(i + 1, curRow)
    
                                If preserveCellsIndex IsNot Nothing Then
    
                                    For Each cellIndex As Integer In preserveCellsIndex
                                        oldCellValue = curRow.Cells(cellIndex).Value
                                        newCellValue = rows(i).Cells(cellIndex).Value
    
                                        rows(i).Cells(cellIndex).Value = oldCellValue
                                        curRow.Cells(cellIndex).Value = newCellValue
                                    Next cellIndex
    
                                End If
    
                            End If
    
                        End If
    
                    Next i
    
            End Select
    
            ' Restore selected rows.
            For i As Integer = 0 To (rows.Count - 1)
    
                If Not rows(i).IsNewRow Then
                    rows(i).Selected = selectedRows.Contains(rows(i).GetHashCode)
                End If
    
            Next i
    
        End Sub
    
    #End Region
    
    End Module
