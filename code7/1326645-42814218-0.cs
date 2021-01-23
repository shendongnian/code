     Public Overrides Function Equals(obj As Object) As Boolean
        Dim other = TryCast(obj, Worksheet)
        If other Is Nothing Then Return False
        Return ParentsAreEqual(other) AndAlso _worksheet.Name.Equals(other._worksheet.Name) 
    End Function
    Private Function ParentsAreEqual(other As Worksheet) As Boolean
        Dim result As Boolean
        Try
            result = _worksheet.Parent.Equals(other._worksheet.Parent)
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function
    Public Overrides Function GetHashCode() As Integer
        Try
            Return _worksheet.Parent.GetHashCode() Xor _worksheet.Name.GetHashCode
        Catch ex As Exception
            Return 42
        End Try
    End Function
