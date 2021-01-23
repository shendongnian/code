    Public Module MyExtensionMethods
    
        <System.Runtime.CompilerServices.Extension()> _
        Public Function ValidateSeName(Of T As { BaseEntity, ISlugSupported })(entity As T, seName As String, name As String, ensureNotEmpty As Boolean) As String
    
        End Function
    
    End Module
