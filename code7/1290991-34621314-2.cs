    Public Event Closed As EventHandler
    Public Event Shown As EventHandler
    
    Protected Overridable Sub whenClosed(ByVal e As EventArgs)
        RaiseEvent Closed(Me, e)
    End Sub
    
    Protected Overridable Sub whenShown(ByVal e As EventArgs)
        RaiseEvent Shown(Me, e)
    End Sub
    
    
       
