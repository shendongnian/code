    Class NameValuePair(Of T)
        Public Property Name As String
        Public Property Value As T
    
        Public Sub New(n As String, v As T)
            Name = n
            Value = v
        End Sub
    
        Public Sub New(n As String)
            Name = n
        End Sub
    
        Public Overrides Function ToString() As String
            Return String.Format("{0} ({1})", Name, Value.ToString)
        End Function
    End Class
