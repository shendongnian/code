    Dim MaxColLen As New Dictionary(Of String, Integer)
    For Each dc As DataColumn In dtSample.Columns
        If dc.DataType Is GetType(String) Then
            MaxColLen.Add(dc.ColumnName, 0)
            For Each dr As DataRow In dtSample.Rows
                If dr.Field(Of String)(dc.ColumnName).Length > MaxColLen(dc.ColumnName) Then
                    MaxColLen(dc.ColumnName) = dr.Field(Of String)(dc.ColumnName).Length
                End If
            Next
        End If
    Next
