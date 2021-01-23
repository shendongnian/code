        Public Shared Function DownloadFileWithQueryString(ByVal httpPath As String, ByVal storePath As String, querystring As String) As String
        Try
            Dim theResponse As HttpWebResponse
            Dim theRequest As HttpWebRequest
            Dim fullurl As String = httpPath & "?" & querystring
            theRequest = HttpWebRequest.Create(fullurl)
            If My.Settings.ProxyURL <> "" Then
                Dim prx As New WebProxy(My.Settings.ProxyURL)
                theRequest.Proxy = prx
            End If
            theResponse = theRequest.GetResponse
            Dim length As Double = theResponse.ContentLength
            Dim writeStream As New IO.FileStream(storePath, IO.FileMode.Create)
            Dim nRead As Integer
            Dim readBytes(4095) As Byte
            Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
            Do Until bytesread = 0
                'speedtimer.Start()
                nRead += bytesread
                writeStream.Write(readBytes, 0, bytesread)
                bytesread = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
            Loop
            'Close the streams
            theResponse.GetResponseStream.Close()
            writeStream.Close()
            Return "OK"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
