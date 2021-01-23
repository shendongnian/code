    Public Class f
        Public Event ItemCheck As EventHandler
        Private c As Class1
        Public Sub New(c1 As Class1)
            c = c1
            AddHandler c.ItemCheck, AddressOf c_ItemCheck
        End Sub
        Private Sub c_ItemCheck(sender As Object, e As ItemCheckEventArgs)
            RaiseEvent ItemCheck(sender, e)
        End Sub
    End Class
