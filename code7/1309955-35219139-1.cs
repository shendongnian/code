    Public Interface ISomeInterface
    
        End Interface
    
        Public Class SomeObject
            Private _someInterface As ISomeInterface
    
    
    
            Public Property SomeInterface As ISomeInterface
                Get
                    Return _someInterface
                End Get
                Set(value As ISomeInterface)
                    If (Not _someInterface Is value) Then
                        If (_someInterface IsNot Nothing) Then
                            DoSomething()
                        End If
    
                        _someInterface = value
    
                        If (_someInterface IsNot Nothing) Then
                            DoSomethingElse()
                        End If
                    End If
                End Set
            End Property
    
    
    
            Public Sub DoSomething()
    
            End Sub
    
            Public Sub DoSomethingElse()
    
            End Sub
        End Class
