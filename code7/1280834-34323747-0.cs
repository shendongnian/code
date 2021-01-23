    Class WizardPages Inherits TabControl
    	Protected Overrides Sub WndProc(ByRef m As Message)
    		
    		If m.Msg = &H1328 AndAlso Not DesignMode Then
    			m.Result = DirectCast(1, IntPtr)
    		Else
    			MyBase.WndProc(m)
    		End If
    
    	End Sub
    
    	Protected Overrides Sub OnKeyDown(ke As KeyEventArgs)
    		
    		If ke.Control AndAlso ke.KeyCode = Keys.Tab Then
    			Return
    		End If
    		MyBase.OnKeyDown(ke)
    	End Sub
    End Class
