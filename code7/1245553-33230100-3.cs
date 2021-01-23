    Imports System.Data
    Imports System.Configuration
    
    Imports System.Web
    
    Imports System.Web.Security
    
    Imports System.Web.UI
    
    Imports System.Web.UI.WebControls
    
    Imports System.Web.UI.WebControls.WebParts
    Imports System.Web.UI.HtmlControls
    
    Public Class CCustomPrincipal
        Implements System.Security.Principal.IPrincipal
    
    
        Private _identity As CCustomIdentity
    
        Public Sub New(identity As CCustomIdentity)
    
    
    
            _identity = identity
        End Sub
    
        Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
    
    
            Get
                Return _identity
            End Get
        End Property
    
    
        Public Function IsInRole(role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
    
    
            Return False
    
        End Function
    
    End Class
