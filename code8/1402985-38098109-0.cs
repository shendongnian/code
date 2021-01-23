    Public Class BaseForm
    
        Private Sub SaveButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveButton.Click
            OnSaveButtonClick()
        End Sub
    
        Protected Overridable Sub OnSaveButtonClick()
            //Do your baseform saving process here
        End Sub
    End Class
    
    Public Class InheritedForm
        Inherits BaseForm
    
        Protected Overrides Sub OnSaveButtonClick()
            //Do your Inherited saving process here 
        End Sub
    End Class
