    Private Sub txtCustCode_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCustCode.MouseClick 
    
        Dim PopUpCustomer As New searchCustomerfrm
        PopUpCustomer.sendingForm = Me
        PopUpCustomer.ShowDialog()
    End Sub
