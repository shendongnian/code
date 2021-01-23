    Private Sub DGVCustomer_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVCustomer.CellContentDoubleClick
    
            sendingForm.txtCustCode.Text = Val(dgvCustomer.Item(1, e.RowIndex).Value)
            Me.Close()
    End Sub
