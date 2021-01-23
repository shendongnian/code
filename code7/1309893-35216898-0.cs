    Public Event NodesInserted As EventHandler(Of TreeModelEventArgs)
    Friend Sub OnNodeInserted(ByVal parent As Node, ByVal index As Integer, ByVal node As Node)
    	If NodesInsertedEvent IsNot Nothing Then 'yes - add the 'Event'
    		Dim args As New TreeModelEventArgs(GetPath(parent), New Integer() { index }, New Object() { node })
    		RaiseEvent NodesInserted(Me, args)
    	End If
    End Sub
