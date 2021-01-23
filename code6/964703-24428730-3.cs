    Public Class doAccountMasters
        Public Property MasterNum As Integer
        Public Property MasterName As String
        Public Property ErrorCode As Integer
        Public Property ErrorDescription As String
    End Class
    <WebMethod(Description:="Returns Array 5 IDs < x", EnableSession:=True)> _
    Public Function GetCustomerIDs(ID As String) As List(Of String)
        Dim output As New List(Of doAccountMasters)()
        Dim sqlCommand As SqlCommand = New SqlCommand( _
            "select top 5 p.MasterNum, p.MasterName, p.ErrorCode, p.ErrorDescription from person.person p where BusinessEntityID<@ID", connection)
        connection.Open()
        sqlCommand.Parameters.Add("@ID", SqlDbType.Int, ID)
        Dim dr = SqlCommand.ExecuteReader()
        While dr.Read
            Dim master As doAccountMasters = New doAccountMasters()
            master.MasterNum = Convert.ToInt32(dr.Item(0))
            master.MasterName = dr.Item(1).ToString()
            master.ErrorCode = Convert.ToInt32(dr.Item(2))
            master.ErrorDescription = dr.Item(3).ToString()
            output.Add(master)
        End While
        connection.Close()
        Return output
    End Function
