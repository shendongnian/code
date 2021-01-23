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
