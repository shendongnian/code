    Public Class AddMonthConverter
        Implements Windows.Data.IValueConverter
    
        Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
            Return addMonths(value, targetType, parameter, True)
        End Function
    
        Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
            Return addMonths(value, targetType, parameter, False)
        End Function
    
        Private Function addMonths(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal isIncrease As Boolean) As Object
            If Not (targetType Is GetType(DateTime?) OrElse targetType Is GetType(DateTime)) Then 
                Throw New InvalidOperationException("The target and value must be a DateTime?")
            Else
                Dim dteValue As DateTime? = CType(value, DateTime?)
                Dim intMonthsToAdd As Int32
    
                If parameter Is Nothing OrElse Int32.TryParse(parameter.ToString, intMonthsToAdd) = False Then
                    intMonthsToAdd = -1
                End If
    
                If dteValue.HasValue Then
                    If isIncrease Then
                        Return dteValue.Value.AddMonths(intMonthsToAdd)
                    Else
                        Return dteValue.Value.AddMonths(-intMonthsToAdd)
                    End If
    
                Else
                    Return dteValue
                End If
    
            End If
        End Function
    End Class
