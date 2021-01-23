    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString") _
                           .ConnectionString
                Exit Select
            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString") _
                          .ConnectionString
                Exit Select
        End Select
        conStr = String.Format(conStr, FilePath, isHDR)
    
        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()
    
        cmdExcel.Connection = connExcel
    
    
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
        connExcel.Close()
    
    
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()
    
    
       
        GridView1.DataSource = dt
        GridView1.DataBind()
    
    End Sub
    
    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowCreated
        ' Check the header type
        If e.Row.RowType = DataControlRowType.Header Then
            Dim litHeader As Literal
            Dim txtSearch As CheckBox
    
    
            ' loop through each cell
            For i As Integer = 0 To (e.Row.Cells.Count - 1)
                litHeader = New Literal
                txtSearch = New CheckBox
    
    
                ' get the current header text
                litHeader.Text = e.Row.Cells(i).Text & "&nbsp;"
    
    
                ' add the header text plus a new textbox
                e.Row.Cells(i).Controls.Add(txtSearch)
                e.Row.Cells(i).Controls.Add(litHeader)
    
            Next
    
    
        End If
    End Sub
