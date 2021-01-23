    Private Function GetImageByteArray(im As Image) As Byte()
        Try
            Using st As System.IO.MemoryStream = New System.IO.MemoryStream
                im.Save(st, Imaging.ImageFormat.Raw)
                Return st.ToArray
            End Using
        Finally
            GC.Collect()
        End Try
    End Function
