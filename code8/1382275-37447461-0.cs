    Using conn As New OleDbConnection(myConnectionString)
        conn.Open()
        Dim dt As DataTable = conn.GetSchema("TABLES", {Nothing, Nothing, Nothing, "TABLE"})
        For Each dr As DataRow In dt.Rows
            Console.WriteLine(dr("TABLE_NAME"))
        Next
    End Using
