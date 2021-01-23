    Public Class B
        Private _a As A
        Public Sub New(a As A)
            _a = a
        End Sub
        Public Function UseThisProperty() As String
            If _a.ThisProperty = 1 Then
                Return "this"
            ElseIf _a.ThisProperty = 2 Then
                Return "other"
            Else
                Return "sth else"
            End If
        End Function
    End Class
