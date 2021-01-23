    Public Shared Function GetCustomer()
          Dim PopUpCustomer As New searchCustomerfrm
          If PopUpCustomer.ShowDialog() = DialogResult.OK Then
               Return Val(DGVCustomer.Item(1, e.RowIndex).Value)
          Else
               Return Nothing
          End If
    End Function
