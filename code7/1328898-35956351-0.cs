            Dim DrContractor As DataRow
            Dim DtContractor As DataTable
            Dim i As Integer
            strQuery = " SELECT * FROM CONTRACTOR ORDER BY CONTCODE"
            Dim DataAdapeter As New SqlDataAdapter(strQuery, myConnection)
            Dim dsDivision As New DataSet
            'myConnection.Open()
            DataAdapeter.Fill(dsDivision, "CONTRACTOR")
            DtContractor = dsDivision.Tables("CONTRACTOR")
            'myConnection.Close()
            cboContractor.Items.Add("ALL")
            For i = 0 To DtContractor.Rows.Count - 1
                DrContractor = DtContractor.Rows(i)
                cboContractor.Items.Add(DrContractor("CONTNAME").ToString & " : " & DrContractor("CONTCODE").ToString)
            Next
            cboContractor.SelectedIndex = 0
            cboContractor.SelectedText = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
