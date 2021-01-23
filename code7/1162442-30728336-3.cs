    Public Property ErrorMsg As String
        Get
            Return Me.litMsg.Text
        End Get
        Set(value As String)
            Me.litMsg.Text = value
        End Set
    End Property
