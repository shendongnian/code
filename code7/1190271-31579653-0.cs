    Module Module1
    
      Sub Main()
        Dim lst As New List(Of ProjectType) From {
            New ProjectType With {.t = "1"},
            New ProjectType With {.t = "2"},
            New ProjectType With {.t = "3"}
        }
        MsgBox(CType(lst(0), SharedType).s) 'This works'
        ProcessSharedTypeEnumerable(lst) 'This does not :-( '
        ProcessSharedTypeEnumerable(lst.Cast(Of SharedType).ToList) 'Neither does this :-( '
      End Sub
    
      Sub ProcessSharedTypeEnumerable(src As IEnumerable(Of SharedType))
        For Each st As SharedType In src
          MsgBox(st.s)
        Next st
      End Sub
    
      Class SharedType
        Property s As String
      End Class
    
      Class ProjectType
        Property t As String
    
        Public Shared Narrowing Operator CType(p As ProjectType) As SharedType
          Return New SharedType With {.s = p.t}
        End Operator
      End Class
    End Module
