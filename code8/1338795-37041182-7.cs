    Imports System.Reflection
    Imports System.Security.Cryptography
    
    Public Class SignedClassBase
        Shared Sub New()
            VerifyAssemblySignature(Assembly.GetCallingAssembly())
        End Sub
    
        Public Sub New()
            VerifyAssemblySignature(Assembly.GetCallingAssembly())
        End Sub
    
        Private Shared Sub VerifyAssemblySignature(assembly As Assembly)
            Dim wasVerified As Boolean
            If Not (NativeMethods.StrongNameSignatureVerificationEx(assembly.Location, True, wasVerified) AndAlso wasVerified) Then
                Throw New CryptographicException("Verification failed: Assembly signature did not match.")
            End If
        End Sub
    End Class
