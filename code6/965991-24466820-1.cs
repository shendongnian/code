    Private Sub DataGridView2_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView2.Scroll
        
            If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then Exit Sub
            If Me.DataGridView1.Rows.Count > 0 And Me.DataGridView2.Rows.Count > 0 Then
                Me.DataGridView1.HorizontalScrollingOffset = e.NewValue 'Me.DataGridView2.HorizontalScrollingOffset
            End If
    
    End Sub
