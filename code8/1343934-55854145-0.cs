    Private Class NoDupValueNameValueCollection
        Inherits Collections.Specialized.NameValueCollection
        Public Overrides Sub Add(name As String, value As String)
            If Not MyBase.AllKeys.Contains(name) OrElse Not MyBase.GetValues(name).Contains(value) Then MyBase.Add(name, value)
        End Sub
    End Class
