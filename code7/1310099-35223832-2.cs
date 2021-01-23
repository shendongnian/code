        Dim dt1 As New DataTable
        dt1.Columns.Add(New DataColumn("A", GetType(System.String)))
        dt1.Columns.Add(New DataColumn("B", GetType(System.String)))
        dt1.Columns.Add(New DataColumn("C", GetType(System.String)))
        For index = 1 To 5
            Dim nr As DataRow = dt1.NewRow
            nr("A") = index
            nr("B") = 10 + index
            nr("C") = "DT1 C value" //Guid.NewGuid.ToString
            dt1.Rows.Add(nr)
        Next
        Dim dt2 As New DataTable
        dt2.Columns.Add(New DataColumn("A", GetType(System.String)))
        dt2.Columns.Add(New DataColumn("B", GetType(System.String)))
        dt2.Columns.Add(New DataColumn("C", GetType(System.String)))
        dt2.Columns.Add(New DataColumn("D", GetType(System.String)))
        For index = 3 To 7
            Dim nr As DataRow = dt2.NewRow
            nr("A") = index
            nr("B") = 10 + index
            nr("C") = "DT2 C Value" //Guid.NewGuid.ToString
            nr("D") = "DT2 value"
            dt2.Rows.Add(nr)
        Next
        Dim master As New DataTable
        Dim DTlist As New List(Of DataTable)
        DTlist.Add(dt1)
        DTlist.Add(dt2)
        //add all your datatables...
        For Each dt As DataTable In DTlist
            //add the column if needed
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
                Dim xpression As String = String.Format("A = {0} AND B = {1}", dr("A"), dr("B"))
                Dim foundRows() As DataRow = master.Select(xpression)
                If foundRows.Count = 0 Then
                    // add a new datarow to the master
                    // value = NonExistent if it//s a datacolumn from the master, that isn//t in the current datatable
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
                            If foundRow(dc.ColumnName).ToString = "NonExistent" Then
                                foundRow(dc.ColumnName) = dr(dc)
                            End If
                        Next
                    Next
                End If
            Next
        Next
        DataGridView1.DataSource = master
