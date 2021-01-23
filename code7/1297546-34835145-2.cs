    Public Class MIConfig
        Public Property Name As String
        Public Property Primary As Integer
        Public Sub New(ByVal name As String, ByVal primary As Integer)
            Me.Name = name
            Me.Primary = primary
        End Sub
    End Class
