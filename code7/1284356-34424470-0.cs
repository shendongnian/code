    Public Sub LoopControls()   '  Assumes this function lives within the scope of a Form
        LoopControls(Me)
    End Sub  
    
    Public Sub LoopControls(ByVal container As Control)
        '
        '  TODO:  Do something with the current control (container)
        '
    
        '
        '  Loop over the current control's inner controls
        '
        If Not Nothing Is container.Controls
            For Each control As Control In container.Controls
                LoopControls(control)
            Next
        End If
    End Sub
