    Public Class Form1
        Public Shadows Event Closed As EventHandler
        Public Shadows Event Shown As EventHandler
    
        Protected Overridable Sub closed1(ByVal e As EventArgs)
            RaiseEvent Closed(Me, e)
        End Sub
    
        Protected Overridable Sub shown1(ByVal e As EventArgs)
            RaiseEvent Shown(Me, e)
        End Sub
    End Class
