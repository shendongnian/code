    Public Module TypeExtensions
        Private NumericTypes As HashSet(Of Type) = New HashSet(Of Type) From {
            GetType(Byte),
            GetType(SByte),
            GetType(Short),
            GetType(UShort),
            GetType(Integer),
            GetType(UInteger),
            GetType(Long),
            GetType(ULong),
            GetType(Single),
            GetType(Double),
            GetType(Decimal),
            GetType(IntPtr),
            GetType(UIntPtr)
        }
        Private NullableNumericTypes As HashSet(Of Type) = New HashSet(Of Type)(
            From type In NumericTypes
            Select GetType(Nullable(Of )).MakeGenericType(type)
        )
        <Extension()>
        Public Function IsNumeric([Me] As Type, Optional allowNullable As Boolean = False) As Boolean
            Return NumericTypes.Contains([Me]) OrElse allowNullable AndAlso NullableNumericTypes.Contains([Me])
        End Function
    End Module
