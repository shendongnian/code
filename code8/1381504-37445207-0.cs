    //targetURL As String, fileAttachment As Byte(), fileName As String, fileExtension As String
    //you don't send the data to the webapi action. You WRITE to it like it's a file        
    Using client = New WebClient()
        Try
            client.Headers.Add("Content-Type", "application/octet-stream")
            Using requestStream As Stream = client.OpenWrite(New Uri(targetURL), "POST")
                requestStream.Write(fileAttachment, 0, fileAttachment.Length)
            End Using    
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.ProtocolError Then
                Dim wbrsp As HttpWebResponse = CType(ex.Response, HttpWebResponse)
                Throw New HttpException(CInt(wbrsp.StatusCode), wbrsp.StatusDescription)
            Else
                Throw New HttpException(500, ex.Message, New Exception("File upload failed."))
            End If
        End Try
    End Using
