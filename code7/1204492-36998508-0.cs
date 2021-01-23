    'This does not work:
    <PrincipalPermission(SecurityAction.Demand, Role:="Administrator")>
    Public Property IsEnabled As Boolean
    
    'This works:
    Private _isEnabled As Boolean
    Public Property IsEnabled As Boolean
      <PrincipalPermission(SecurityAction.Demand, Role:="Administrator")>
      Get
        Return _isEnabled
      End Get
      <PrincipalPermission(SecurityAction.Demand, Role:="Administrator")>
      Set (value As Boolean)
        _isEnabled = value
      End Set
    End Property
