    Private Sub TreeViewBuilderButton_Click(sender As System.Object, e As System.EventArgs) Handles TreeViewBuilderButton.Click
        Dim nd As TreeNode = TestTreeView.Nodes.Add("C1", "City1")
        addChildren(nd)
        nd = TestTreeView.Nodes.Add("C2", "City2")
        addChildren(nd)
        nd = TestTreeView.Nodes.Add("C3", "City3")
        addChildren(nd)
        TestTreeView.ExpandAll()
    End Sub
    Private Sub addChildren(nd As TreeNode)
        nd.Nodes.Add(String.Concat(nd.Name, "_House"), "House")
        nd.Nodes.Add(String.Concat(nd.Name, "_Hotel"), "Hotel")
        nd.Nodes.Add(String.Concat(nd.Name, "_Shop"), "Shop")
        nd.Nodes.Add(String.Concat(nd.Name, "_Bank"), "Bank")
        nd.Nodes.Add(String.Concat(nd.Name, "_School"), "School")
    End Sub
    Private Sub TestTreeView_AfterCheck(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TestTreeView.AfterCheck
        Try
            If (e.Action <> TreeViewAction.Unknown) Then
                Dim nd As TreeNode = DirectCast(e.Node, TreeNode)
                nd.Parent.Checked = nd.Checked
                Debug.Print(String.Concat("Node: ", nd.Text, " Node Name: ", nd.Name, " Parent: ", nd.Parent.Text, " Parent Name:", nd.Parent.Name))
            End If
        Catch ex As Exception
            MessageBox.Show(String.Concat("An error occurred: ", ex.Message))
        End Try
    End Sub
