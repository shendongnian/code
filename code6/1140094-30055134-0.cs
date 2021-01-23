    Public Class RelayCommand : Implements ICommand
    Private _execute As Action(Of Object)
    Private _canExecute As Predicate(Of Object)
    Private Event canExecuteChangedInternal As EventHandler
    Public Sub New(ByVal execute As Object)
        Me.New(execute, AddressOf DefaultCanExecute)
    End Sub
    Public Sub New(ByVal execute As Action(Of Object), ByVal canExec As Predicate(Of Object))
        If execute Is Nothing Then
            Throw New ArgumentException("execute")
        End If
        If canExec Is Nothing Then
            Throw New ArgumentException("canExec")
        End If
        _execute = execute
        _canExecute = canExec
    End Sub
    Public Function CanExecute(ByVal param As Object) As Boolean Implements ICommand.CanExecute
        Return _canExecute IsNot Nothing AndAlso _canExecute(param)
    End Function
    Public Sub Execute(ByVal obj As Object) Implements ICommand.Execute
        _execute(obj)
    End Sub
    Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
        AddHandler(ByVal value As EventHandler)
            AddHandler canExecuteChangedInternal, value
        End AddHandler
        RemoveHandler(value As EventHandler)
            RemoveHandler canExecuteChangedInternal, value
        End RemoveHandler
        RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent canExecuteChangedInternal(sender, e)
        End RaiseEvent
    End Event
    Public Sub OnCanExecuteChanged(ByVal param As Object)
        Dim handler As EventHandler = canExecuteChangedInternalEvent
        If handler IsNot Nothing Then
            handler.Invoke(Me, EventArgs.Empty)
        End If
    End Sub
    Public Sub Destroy()
        _canExecute = Function(unused) False
        Me._execute = Sub(unused)
                          Return
                      End Sub
    End Sub
    Private Shared Function DefaultCanExecute(ByVal param As Object) As Boolean
        Return True
    End Function
    End Class
