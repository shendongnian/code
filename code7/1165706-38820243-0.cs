    Dim queryString As String = "select user_name,user_lastname,user_address from usertable"
    Using connection As New OdbcConnection(connectionString)
        Dim command As New OdbcCommand(queryString, connection)
        connection.Open()
        Dim reader As OdbcDataReader = command.ExecuteReader()
        While reader.Read()
            Console.WriteLine("user name={0}", reader(0).ToString)
            Console.WriteLine("user lastname{0}", reader("user_lastname").ToString)
        End While      
        reader.Close()
    End Using
