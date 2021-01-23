    <Extension()>
    Public Function FromBytesToBase64(b As Byte()) As String
        If b Is Nothing Then Return ""
        Return Convert.ToBase64String(b)
    End Function
    <Extension()>
    Public Function FromBase64ToBytes(s As String) As Byte()
        If s Is Nothing Then Return Nothing
        Return Convert.FromBase64String(s)
    End Function
