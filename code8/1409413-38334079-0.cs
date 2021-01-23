    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles    Button1.Click
    Dim db_comm As New NpgsqlCommand
    Dim Reader As NpgsqlDataReader
    Dim query As String = "Select code1,name1 from clientes"
    db_comm.CommandText = query
    db_comm.Connection = conn
    conn.open
    Reader = db_comm.ExecuteReader
    Dim list As New List(Of String) -->  wrong; this should be MyListOfClient
    While Reader.Read
        list.Add(Reader.GetString("code1"))
        list.Add(Reader.GetString("name1"))
    End While
    Dim API As APICS.Service1Client = New APICS.Service1Client()
    API.InsertClientsAsyn(list) --> wrong; this should be MyListOfClient
