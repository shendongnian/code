    Private Sub YourForm_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd
    
    	Dim intRowHeadersWidthDefault As Integer = 41 'this is a default value; you can save it on form load
    	Dim intVerticalScrollbarWidth As Integer = SystemInformation.VerticalScrollBarWidth
    
    	If Not Me.DataGridView1.Controls.OfType(Of VScrollBar)()(0).Visible Then
    		intVerticalScrollbarWidth = 0
    	End If
    
    	Dim intSpaceToFill As Integer = (Me.DataGridView1.Width - intRowHeadersWidthDefault - intVerticalScrollbarWidth)
    
    	Dim intColumnWidth As Integer = intSpaceToFill / 8
    
    	For i As Integer = 0 To Me.DataGridView1.ColumnCount - 1
    		Me.DataGridView1.Columns(i).Width = intColumnWidth
    	Next i
    
    	Me.DataGridView1.RowHeadersWidth = intRowHeadersWidthDefault + intSpaceToFill - (intColumnWidth * 8)
    
    End Sub
