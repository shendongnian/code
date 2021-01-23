    Private Sub Print_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            Dim ts As ToolStrip = TryCast(reportViewer.Controls.Find("toolstrip1", True).First, ToolStrip)
            If Not ts Is Nothing Then
                For Each tsb As ToolStripItem In ts.Items
                    If TypeOf tsb Is ToolStripButton AndAlso
                    (TryCast(tsb, ToolStripButton).Name = "firstPage" Or
                    TryCast(tsb, ToolStripButton).Name = "lastPage" Or
                    TryCast(tsb, ToolStripButton).Name = "previousPage" Or
                    TryCast(tsb, ToolStripButton).Name = "nextPage") Then
                        AddHandler tsb.Click, AddressOf tsb_Click
                    End If
                Next
            End If
    End Sub
