    Public Class Result
        Public Property ElementName As String
        Public Property Id As Integer
        Public Property Name As String
    End Class
    Public Class GetValues
        Public Property Count As Integer
        Public Property Message As String
        Public Property SearchCriteria As String
        Public Property Results As Result()
    End Class
