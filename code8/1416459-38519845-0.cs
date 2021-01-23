        Dim bytes(16) As Byte
        Using fs As New IO.FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            fs.Read(bytes, 0, 16)
        End Using
        Dim chkStr As String = System.Text.ASCIIEncoding.ASCII.GetString(bytes)
        Return chkStr.Contains("SQLite format")
