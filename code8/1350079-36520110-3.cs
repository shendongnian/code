    Public Class Person
        Inherits System.Web.UI.UserControl
    
        Private msFirstName As String
        Public Property FirstName() As String
            Get
                Return msFirstName
            End Get
            Set(ByVal value As String)
                msFirstName = value
            End Set
        End Property
    End Class
