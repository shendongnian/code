    Public Class SearchValueConverter
    Implements IMultiValueConverter
    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IMultiValueConverter.Convert
        Dim cellText As String = If(values(0) Is Nothing, String.Empty, values(0).ToString())
        Dim searchText As String = TryCast(values(1), String)
        If Not String.IsNullOrEmpty(searchText) AndAlso Not String.IsNullOrEmpty(cellText) Then
            If cellText.ToLower().Contains(searchText.ToLower()) Then
                Return True 
            Else
                Return False
            End If
        End If
        Return False
    End Function
    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As Globalization.CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Return Nothing
    End Function
    End Class
 
