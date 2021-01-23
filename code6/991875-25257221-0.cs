    Public Class Class1
        Inherits ComboBox
    
        Public Event ItemCheck As ItemCheckEventHandler
    
        Public Sub RaiseItemCheckEvent(ByVal sender As Object, ByVal e As ItemCheckEventArgs)
            RaiseEvent ItemCheck(sender, e)
        End Sub
    
        Public Class f
            Private c As Class1
    
            Public Sub New(ByVal c1 As Class1)
                c = c1
                AddHandler c.ItemCheck, AddressOf c_ItemCheck
            End Sub
    
            Private Sub c_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs)
                c.RaiseItemCheckEvent(sender, e)
            End Sub
    
        End Class
    
    End Class
