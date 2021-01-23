      Private Sub TabControl1_ControlAdded(sender As Object, e As ControlEventArgs) Handles TabControl1.ControlAdded
        Debug.WriteLine("Something added: " & e.Control.Name & " " & e.Control.GetType().ToString)
    
        If e.Control.GetType.ToString = "System.Windows.Forms.TabPage" Then
          Dim tp As TabPage = CType(e.Control, TabPage)
          tp.UseVisualStyleBackColor = False
        End If
      End Sub
