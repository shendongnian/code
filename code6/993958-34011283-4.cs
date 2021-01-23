    Public NotInheritable Class DataGridTextSearch
    Private Sub New()
    End Sub
    Public Shared ReadOnly SearchValueProperty As DependencyProperty = DependencyProperty.RegisterAttached("SearchValue", GetType(String), GetType(DataGridTextSearch), New FrameworkPropertyMetadata(String.Empty, FrameworkPropertyMetadataOptions.[Inherits]))
    Public Shared Function GetSearchValue(obj As DependencyObject) As String
        Return DirectCast(obj.GetValue(SearchValueProperty), String)
    End Function
    Public Shared Sub SetSearchValue(obj As DependencyObject, value As String)
        obj.SetValue(SearchValueProperty, value)
    End Sub
    Public Shared ReadOnly IsTextMatchProperty As DependencyProperty = DependencyProperty.RegisterAttached("IsTextMatch", GetType(Boolean), GetType(DataGridTextSearch), New UIPropertyMetadata(False))
    Public Shared Function GetIsTextMatch(obj As DependencyObject) As Boolean
        Return CBool(obj.GetValue(IsTextMatchProperty))
    End Function
    Public Shared Sub SetIsTextMatch(obj As DependencyObject, value As Boolean)
        obj.SetValue(IsTextMatchProperty, value)
    End Sub
    End Class
