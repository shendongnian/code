    Public MustInherit Class Place
          Public MustOverride Property Name as String
    End Class
    <Export>
    Public Class Library
         Inherits Place  
        
         Public Overrides Property Name as String = "Library"
    End Class
    
    <Export>
    Public Class Home
          Inherits Place
    
        Public Overrides Property Name as String = "Home"
    End Class
