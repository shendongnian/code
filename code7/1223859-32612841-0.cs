        Using msi = New MemoryStream(bytes)
            Using mso = New MemoryStream()
                Using gs = New System.IO.Compression.GZipStream(msi, System.IO.Compression.CompressionMode.Decompress)
                    Dim bytesAux As Byte() = New Byte(4095) {}
                    Dim cnt As Integer
                    While (InlineAssignHelper(cnt, gs.Read(bytesAux, 0, bytesAux.Length))) <> 0
                        mso.Write(bytesAux, 0, cnt)
                    End While
                End Using
                Dim streamReader As StreamReader = New StreamReader(mso, System.Text.Encoding.UTF8, True)
                Dim XmlDoc As String
                mso.Seek(0, SeekOrigin.Begin)
                XmlDoc = streamReader.ReadToEnd               
                Return XmlDoc
            End Using
        End Using
    End Function`
