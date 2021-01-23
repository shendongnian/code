    Using reader As New StreamReader(ofd_tracking_file.FileName)
        Dim line As String = Nothing
        Do
            line = reader.ReadLine()
            Debug.Write(line)
        Loop Until line Is Nothing
    End Using
