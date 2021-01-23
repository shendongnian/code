    Sub Main()
        Dim lst As New List(Of ProjectType) From {
            New ProjectType With {.s = "1"},
            New ProjectType With {.s = "2"},
            New ProjectType With {.s = "3"}
        }
        SharedType.ProcessSharedTypeEnumerable(lst)
    End Sub
    
    Shared Sub ProcessSharedTypeEnumerable(src As IEnumerable(Of SharedType))
        For Each st As SharedType In src
            MsgBox(st.s)
        Next
    End Sub
    Class SharedType
        Property s As String
    End Class
    
    Class ProjectType
        Inherits SharedType
    End Class
