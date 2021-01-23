    Sub ShiftCaseLower()
        For Each c As Control In FlowLayoutPanel1.Controls
            If c.Tag = "c" Then c.Text = c.Text.ToLower
        Next
    End Sub
    Sub ShiftCaseUpper()
        For Each c As Control In FlowLayoutPanel1.Controls
            If c.Tag = "c" Then c.Text = c.Text.ToUpper
        Next
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, btnQ.Click
        ' all "key" click events handled here
        TextBox1.AppendText(sender.text)
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ' Shift key
        If Asc(btnQ.Text) = Asc("Q") Then
            ShiftCaseLower()
        Else
            ShiftCaseUpper()
        End If
    End Sub
