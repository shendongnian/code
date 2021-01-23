        Dim master As New DataTable
        Dim DTlist As New List(Of DataTable)
        DTcol.Add(dt1)
        DTcol.Add(dt2)
        //add all your datatables...
        For Each dt As DataTable In DTlist
            For Each dc As DataColumn In dt.Columns
                If master.Columns.Contains(dc.ColumnName) Then
                    Continue For
                Else
                    Dim newColumn As New Data.DataColumn(dc.ColumnName, GetType(System.String))
                    newColumn.DefaultValue = "NonExistent"
                    master.Columns.Add(newColumn)
                    // Assuming equal datatable rows & index-match
                    For index = 0 To dt.Rows.Count - 1
                        master(index)(dc) = dt(index)(dc)
                    Next
                End If
            Next
        Next
