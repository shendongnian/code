    Public Shared Function GetCustomer()
          Dim PopUpCustomer As New searchCustomerfrm
          If PopUpCustomer.ShowDialog() = DialogResult.OK Then
               Return Val(PopUpCustomer.DGVCustomer.Item(1, PopUpCustomer.DGVCustomer.CurrentRow.Index).Value) 
          Else
               Return Nothing
          End If
    End Function
