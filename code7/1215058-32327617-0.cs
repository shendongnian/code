    Public Class TabBasedMultipage : Inherits TabControl
        Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
            MyBase.OnControlAdded(e)
            Dim tabPage As TabPage = TryCast(e.Control, TabPage)
            If tabPage IsNot Nothing Then
                tabPage.UseVisualStyleBackColor = False
            End If
        End Sub
    End Class
