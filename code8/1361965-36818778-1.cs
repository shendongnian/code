    Imports System.Runtime.CompilerServices
    Module StringExtensions
        <Extension()>
        Public Function IsNullOrEmpty(ByVal value As String) As Boolean
            IsNullOrEmpty = String.IsNullOrEmpty(value)
        End Function
    End Module
