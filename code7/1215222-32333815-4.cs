    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property Selected As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            Throw New InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", New Object() { "Selected" }))
        End Set
    End Property
 
