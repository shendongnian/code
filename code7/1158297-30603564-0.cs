    Imports System.Windows.Data
    
    Public Class MappingConverter
        Implements IValueConverter
    
        Public Property Mappings As New List(Of Mapping)
    
    
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            Return Mappings.Where(Function(m) m.Source = value.ToString).FirstOrDefault
        End Function
    
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException
        End Function
    End Class
    
    Public Class Mapping
        Public Property Source As String
        Public Property Target As Object
    End Class
