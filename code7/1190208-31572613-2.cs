          Private Sub ubFilepath_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ubFilepath.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.Text) Then
                Me.ubFilepath.Text = e.Data.GetData("Text")
            ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim fileNames() As String
                Dim MyFilename As String
                fileNames = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
                MyFilename = fileNames(0)
                Me.ubFilepath.Text = MyFilename
     
            //RenPrivateItem is from outlook
            ElseIf e.Data.GetDataPresent("RenPrivateItem") Then
                Dim thestream As System.IO.MemoryStream = e.Data.GetData("FileGroupDescriptor")
                Dim filename As New System.Text.StringBuilder("")
                Dim fileGroupDescriptor(700) As Byte
                Try
                    thestream.Read(fileGroupDescriptor, 0, 700)
                    Dim i As Integer = 76
                    While fileGroupDescriptor(i) <> 0
                        filename.Append(Convert.ToChar(fileGroupDescriptor(i)))
                        i += 1
                    End While
                    Me.ubFilepath.Text = "Outlook attachment_" + filename.ToString
                    ms = e.Data.GetData("FileContents", True)
                Finally
                    If thestream IsNot Nothing Then thestream.Close()
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Only files can be dragged into this box")
        End Try
