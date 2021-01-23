        Dim master As New DataTable
        Dim DTlist As New List(Of DataTable)
        DTcol.Add(dt1)
        DTcol.Add(dt2)
        //add all your datatables...
        For Each dt As DataTable In DTlist
            // add the column if needed
            For Each dc As DataColumn In dt.Columns
                If master.Columns.Contains(dc.ColumnName) Then
                    Continue For
                Else
                    Dim newColumn As New Data.DataColumn(dc.ColumnName, GetType(System.String))
                    newColumn.DefaultValue = "NonExistent"
                    master.Columns.Add(newColumn)
                End If
            Next
            // add the values
            For Each dr As DataRow In dt.Rows
                Dim xpression As String = String.Format("[Block Number] = {0} AND Angle = {1}", dr("Block Number"), dr("Angle"))
                Dim foundRows() As DataRow = master.Select(xpression)
                If foundRows Is Nothing Then
                    // add a new datarow to the master
                    // value = NonExistent if it's a datacolumn from the master, that isn't in the current datatable
                    Dim newRow As DataRow = master.NewRow
                    For Each dc As DataColumn In master.Columns
                        If dt.Columns.Contains(dc.ColumnName) Then
                            newRow(dc.ColumnName) = dr(dc.ColumnName)
                        Else
                            newRow(dc.ColumnName) = "NonExistent"
                        End If
                    Next
                    master.Rows.Add(newRow)
                Else
                    // add values to the existing rows
                    For Each foundRow As DataRow In foundRows
                        For Each dc As DataColumn In dt.Columns
                            If foundRow(dc).ToString = "NonExistent" Then
                                foundRow(dc) = dr(dc)
                            End If
                        Next
                    Next
                End If
            Next
        Next
