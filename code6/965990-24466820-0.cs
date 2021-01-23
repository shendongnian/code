    Private Sub DataGridView1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
          
            If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then Exit Sub
            If Me.DataGridView2.Rows.Count > 0 And Me.DataGridView1.Rows.Count > 0 Then
                Me.DataGridView2.HorizontalScrollingOffset = e.NewValue 'Me.DataGridView1.HorizontalScrollingOffset
            End If
    
    End Sub
