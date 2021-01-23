      Module Module1
        
            Sub Main()
                Dim test As d = New d()
                test.EntityID = 52
                Dim t As Integer = test.EntityID
                Dim t1 As Integer = test.GetEntityID
        
            End Sub
        
        
            Public Class a
                Dim _entityId As Integer
                Protected Friend Property EntityID() As Integer
                    Get
                        Return _entityId
                    End Get
                    Set(ByVal Value As Integer)
                        _entityId = Value
                    End Set
                End Property
        
            End Class
        
        
            Public Class b
                Inherits a
        
            End Class
        
        
            Public Class c
                Inherits b
        
            End Class
        
            Public Class d
                Inherits c
        
        
                Public Function GetEntityID() As Integer
        
                    Dim test As Integer = Me.EntityID
                    Return test
                End Function
        
            End Class
        
        End Module
