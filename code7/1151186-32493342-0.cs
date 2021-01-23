    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            Dim _ConnectionString As String = ConfigurationManager.AppSettings("ConnectionString")
            Dim UserId As String = context.Request.QueryString("Id")
            Dim con As New SqlConnection(_ConnectionString)
            Try
                con.Open()
                Dim cmd As New SqlCommand(Convert.ToString("select UserPhoto from tblEmployee where EmpId=") & UserId, con)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    context.Response.BinaryWrite(DirectCast(dr(0), Byte()))
                Else
                    Dim imgpath As String = context.Server.MapPath("~/images/images.jpg")
                    Dim byteArray As Byte() = File.ReadAllBytes(imgpath)
                    context.Response.BinaryWrite(byteArray)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
