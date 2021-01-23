    Private LastSelectetNode As TreeNode
    
    Protected Overrides Sub OnBeforeSelect(e As TreeViewCancelEventArgs)
        e.Cancel = LastSelectetNode Is Nothing  
        MyBase.OnBeforeSelect(e)
    End Sub
    
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        Dim nd = MyBase.HitTest(e.Location).Node
        If LastSelectetNode Is nd Then
            SelectedNode = Nothing
            LastSelectetNode = Nothing
        Else
            LastSelectetNode = nd
        End If
        MyBase.OnMouseUp(e)
    End Sub
