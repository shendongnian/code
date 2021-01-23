    Public Sub Button4_SelectLessee_Click(sender As Object, e As EventArgs) Handles Button4_SelectLessee.Click
        If Me.Owner IsNot Nothing AndAlso Me.Owner.GetType() Is GetType(AddData) Then
            Dim AddDataFrm As AddData = DirectCast(Me.Owner, AddData)
            AddDataFrm.LesseeId = TextBox1_LesseeID.Text
            AddDataFrm.LesseeName = TextBox2_LesseeName.Text
        End If
    End Sub
