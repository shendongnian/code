    Private Sub buttonClicked(sender As Object, e As EventArgs)
        'Handle the click event here.
        Dim clickedButton As Button = CType(sender, Button)
        For Each c As Control In Controls
            If TypeOf c Is Button Then
                If Not c.Equals(clickedButton) Then
                    c.Visible = False
                End If
            End If
        Next
    End Sub
