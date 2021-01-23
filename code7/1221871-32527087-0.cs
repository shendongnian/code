    Public Class Foo
        Implements ICustomTypeDescriptor
        Public Property P1 As String
        Public Property P2 As String
        Public Property P3 As String
        Public Property P4 As String
        Public Property P5 As String
        Public Property P6 As String
        Public Property P7 As String
        Public Property P8 As String
        Public Property P9 As String
        Private Function GetProperties(attributes() As Attribute) As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
            Dim properties = {"P1", "P3", "P7"}
            Dim descriptors = TypeDescriptor _
                .GetProperties(GetType(Foo)) _
                .Cast(Of PropertyDescriptor) _
                .Where(Function(p) properties.Any(Function(s) s = p.Name)) _
                .ToArray()
            Return New PropertyDescriptorCollection(descriptors)
        End Function
        Private Function GetAttributes() As AttributeCollection Implements ICustomTypeDescriptor.GetAttributes
            Return New AttributeCollection(Nothing)
        End Function
        Private Function GetClassName() As String Implements ICustomTypeDescriptor.GetClassName
            Return Nothing
        End Function
        Private Function GetComponentName() As String Implements ICustomTypeDescriptor.GetComponentName
            Return Nothing
        End Function
        Private Function GetConverter() As TypeConverter Implements ICustomTypeDescriptor.GetConverter
            Return Nothing
        End Function
        Private Function GetDefaultEvent() As EventDescriptor Implements ICustomTypeDescriptor.GetDefaultEvent
            Return Nothing
        End Function
        Private Function GetDefaultProperty() As PropertyDescriptor Implements ICustomTypeDescriptor.GetDefaultProperty
            Return Nothing
        End Function
        Private Function GetEditor(editorBaseType As Type) As Object Implements ICustomTypeDescriptor.GetEditor
            Return Nothing
        End Function
        Private Function GetEvents() As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
            Return New EventDescriptorCollection(Nothing)
        End Function
        Private Function GetEvents(attributes() As Attribute) As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
            Return New EventDescriptorCollection(Nothing)
        End Function
        Private Function GetProperties() As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
            Return DirectCast(Me, ICustomTypeDescriptor).GetProperties(Nothing)
        End Function
        Private Function GetPropertyOwner(pd As PropertyDescriptor) As Object Implements ICustomTypeDescriptor.GetPropertyOwner
            Return Me
        End Function
    End Class
