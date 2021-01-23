    Module Module1
    
      Sub Main()
        Dim lst As New List(Of ProjectType)
        lst.Add(New ProjectType With {.t = "1"})
        lst.Add(New ProjectType With {.t = "2"})
        lst.Add(New ProjectType With {.t = "3"})
    
        SharedType.ProcessSharedTypeEnumerable(lst)
    
      End Sub
    
    
      Class SharedType
        Friend Shared Sub ProcessSharedTypeEnumerable(src As IEnumerable(Of ISharedTypeMappable))
          For Each stm As ISharedTypeMappable In src
            Dim st As SharedType = stm.ToSharedType
            Console.WriteLine(st.s)
          Next stm
          Console.ReadKey()
        End Sub
        Property s As String
      End Class
    
      Class ProjectType
        Implements ISharedTypeMappable
    
        Property t As String
    
        Public Function ToSharedType() As SharedType Implements ISharedTypeMappable.ToSharedType
          Return New SharedType With {.s = Me.t}
        End Function
      End Class
    
      Public Interface ISharedTypeMappable
        Function ToSharedType() As SharedType
      End Interface
    
    End Module
