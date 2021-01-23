    Module Module1
        Sub Main()
            Dim context As ModernIpg.wsContext = New ModernIpg.wsContext() With {.data = New ModernIpg.wsContextEntry(1)}
        End Sub
    End Module
    Public Class ModernIpg
        Public Class wsContext
            Public data As wsContextEntry
        End Class
        Public Class wsContextEntry
            Sub New(x As Integer)
            End Sub
        End Class
    End Class​
