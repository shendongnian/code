    Public MustInherit Class Person
        Public MustOverride Property Name as String
    End Class
    <Export>
    Public Class Joe
         Inherits Person
    
         Public Overrides Property Name as String = "Joe"
    End Class
    
    <Export>
    Public Class Bob
         Inherits Person
    
         Public Overrides Property Name as String = "Bob"
    End Class
