    Public Sub RefreshUC()
    Try
        Me.Measure(New Size(400, 400))
        Me.Arrange(New Rect(New Size(400, 400)))
        Dim GD As Grid = Me.Parent
        Dim KP As Page = GD.Parent
        KP.Content = New BarGraph
        KP.Measure(New Size(400, 400))
        KP.Arrange(New Rect(New Size(400, 400)))
    Catch ex As Exception
    End Try
    End Sub
