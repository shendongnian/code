    Dim Data As String
    Dim reader As StreamReader = Nothing
    Dim NsStream As NetworkStream = Nothing
    dim address as IPAddress = IPAddress.Parse("192.168.0.50")
    Dim ipe As New IPEndPoint(address, port)
    Dim telnetSocket As New Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
    
    telnetSocket.Connect(ipe)
    
     If (telnetSocket.Connected) Then
         Try
        
             NsStream = New NetworkStream(telnetSocket, True)
             reader = New StreamReader(NsStream)
    
             Do While (Not reader.EndOfStream)
    
                 ' Read the line of data
                  Data = reader.ReadLine()
                 'Do whatever with data
             Loop
        
        Catch ex As Exception
               Msgbox(ex.message)
        Finally
                Try
                    If reader IsNot Nothing Then
                        reader.Close()
                    End If
                Catch ex As Exception
                End Try
                Try
                    If NsStream IsNot Nothing Then
                        NsStream.Close()
                    End If
                Catch ex As Exception
                End Try
            End Try
    
    end if
