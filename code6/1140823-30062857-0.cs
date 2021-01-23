    Public Sub New(ByVal execute As Action(Of Object))
        MyClass.New(execute, AddressOf DefaultCanExecute)
    End Sub
    Public Sub New(ByVal execute As Action(Of Object), 
                   ByVal canExec As Predicate(Of Object))
        'stuff...
    End Sub
