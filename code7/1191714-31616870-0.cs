    Dim lp As Integer = 0, tp As Integer = 0  'lp-left position, tp-top position in Your groupBox
    For x = 1 to 20
     Dim btn As New Button
     btn.ID = "btn" + x.ToString
     btn.Text = x.ToString
     btn.Left = lp
     btn.Top = tp
     btn.Size = New Size(30, 30)
     AddHandler btn.Click, AddressOf btnClick
     groupBox.Controls.Add(btn)
     tp += btn.Height + 10
    Next
    
    Private Sub btnClick(sender As Object, e As EventArgs)
     Dim btn As Button = DirectCast(sender, Button)
     'for example
     If btn.ID = "btn1" Then
      'do something if You click on first button, ...
     End If
    End Sub
