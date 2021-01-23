    	Private Sub DataGridView1_EditingControlShowing( sender As Object,  e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
		    AddHandler e.Control.TextChanged, AddressOf CellTextChanged
	    End Sub
	private sub cellTextChanged(sender as object, e as EventArgs)
		dim textCtrl as DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
		console.WriteLine(textCtrl.Text)
	end sub
