    ...
    Public Property ODQClient As Object
        Get
            ODQClient = _ODQ
        End Get
        Set(value As Object)
            _ODQ = value            ' <<< compiler error  
        End Set
    End Property
