    Dim scrolled As New List(Of Integer)
    Private Sub reportViewer_PageNavigation(sender As Object, e As PageNavigationEventArgs) Handles reportViewer.PageNavigation
        scrolled.Add(e.NewPage)
    End Sub
    Private Sub reportViewer_MouseWheel(sender As Object, e As MouseEventArgs) Handles reportViewer.MouseWheel
        If scrolled.Count > 1 Then
            reportViewer.CurrentPage = scrolled.Item(scrolled.Count - 2)
            scrolled.Clear()
        ElseIf scrolled.Count = 1 Then
            reportViewer.CurrentPage = scrolled.Item(scrolled.Count - 1)
            scrolled.Clear()
        End If
    End Sub
    Public Sub tsb_Click(ByVal sender As Object, ByVal e As EventArgs)
        scrolled.Clear()
    End Sub
