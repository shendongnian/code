    Public Interface IDeviceTable
        Property ID() As Long
        Property Name() As String
    End Interface
    Partial Public Class Blade
        Implements IDeviceTable
        Public Property ID1 As Long Implements IDeviceTable.ID
            Get
                Return Me.ID
            End Get
            Set(value As Long)
                Me.ID = value
            End Set
        End Property
        Public Property Name1 As String Implements IDeviceTable.Name
            Get
                Return Me.Name
            End Get
            Set(value As String)
                Me.Name = value
            End Set
        End Property
    End Class
    Partial Public Class Diode
        Implements IDeviceTable
        ' etc.
    End Class
