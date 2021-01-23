    Public Class B
        Public Property a As A
        Public Function UseThisProperty() As String
            If a.ThisProperty = 1 Then
                Return "this"
            ElseIf a.ThisProperty = 2 Then
                Return "other"
            Else
                Return "sth else"
            End If
        End Function
    End Class
