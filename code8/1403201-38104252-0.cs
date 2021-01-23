    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
     If e.Node.Text = "Purchase" Then
          Dim frm As New frm_purchase
          frm.Show(ParentForm)
     End If
