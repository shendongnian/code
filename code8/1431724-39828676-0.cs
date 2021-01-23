      ' Enter the listening loop. 
            While True
                Console.Write(listeningPort & " Waiting for a connection... " & vbLf)
                ' Perform a blocking call to accept requests. 
                ' You could also user server.AcceptSocket() here. 
                Dim client As TcpClient = server.AcceptTcpClient()
                Console.WriteLine(listeningPort & " Connected!")
                data = Nothing
                ' Get a stream object for reading and writing 
                Dim stream As NetworkStream = client.GetStream()
                stream.ReadTimeout = 180000
                Dim i As Int32
                ' Loop to receive all the data sent by the client.
                i = stream.Read(bytes, 0, bytes.Length)
                While (i <> 0)
                    ' Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                    Console.WriteLine(listeningPort & " Received: {0}", data)
                    If Trim(data) <> "" Then
                        If Trim(data).StartsWith("##,") Then
                            Dim byte1 As Byte() = System.Text.Encoding.ASCII.GetBytes("LOAD")
                            stream.Write(byte1, 0, byte1.Length)
                        ElseIf Trim(data).EndsWith(";") And Trim(data).Contains("imei:") = False Then
                            Dim byte1 As Byte() = System.Text.Encoding.ASCII.GetBytes("**,imei:" & data.Replace(";", ",B;"))
                            stream.Write(byte1, 0, byte1.Length)
                        Else
	           'TODO: PROCESS THE DATA HERE
                            Dim byte1 As Byte() = System.Text.Encoding.ASCII.GetBytes("ON")
                            stream.Write(byte1, 0, byte1.Length)
                        End If
                    End If
               
                    Try
                        i = stream.Read(bytes, 0, bytes.Length)
                    Catch ex As IOException     'Added For the Timeout, End Connection and Start Again
                        If ex.Message.Contains("did not properly respond after a period of time") Then
                            'WriteLog("Port: " & listeningPort & " IOException: " & ex.Message)
                            client.Close()
                            server.Server.Close()
                            server.Stop()
                        Else
                            Try
                                client.Close()
                                server.Server.Close()
                                server.Stop()
                            Catch e As Exception
                                'WriteLog("Port: " & listeningPort & " Error in Closing Port. : " & e.Message)
                            End Try
                        End If
                        GoTo finalblock
                    End Try
                End While
                ' Shutdown and end connection
                client.Close()
            End While
