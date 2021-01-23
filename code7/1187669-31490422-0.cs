    Public MustInherit Class TableBase
      public property row As RowBase
      Default Public MustOverride ReadOnly Property Rows(iID As Integer) As RowBase
    End Class
    
    Default Public Overrides ReadOnly Property Rows(iID As Integer) As RowBase
        row.Name=iTD
        End Get
    End Property
