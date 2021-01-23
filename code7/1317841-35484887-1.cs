    Public Class KeyedStack(Of T)
        Private myStack As Stack(Of NameValuePair(Of T))
    
        Public Sub New()
            myStack = New Stack(Of NameValuePair(Of T))
        End Sub
    
        Public Sub Push(key As String, value As T)
            Dim item = myStack.FirstOrDefault(Function(k) String.Compare(k.Name, key, True) = 0)
            If item IsNot Nothing Then
                ' replace
                item.Value = value
            Else
                myStack.Push(New NameValuePair(Of T)(key, value))
            End If
        End Sub
    
        Public Function Pop() As T
            ' todo check count
            Dim item = myStack.Pop
            Return item.Value
        End Function
    
        Public Function Peek() As T
            Return myStack.Peek().Value
        End Function
    
        ' ToDo: add Count, Contains, ContainsKey as needed
    End Class
