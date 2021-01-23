    Public Sub Draw()
        Using g as Graphics = Me.CreateGraphics()
            For Each Appliance in Appliances
                g.DrawImage(Appliance.Image, Appliance.X, Appliance.Y)
            Loop
        End Using
    End Sub    
