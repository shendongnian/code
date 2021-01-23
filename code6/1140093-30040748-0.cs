    Friend Class ActionCommand
    	Implements ICommand
    
    	Private _execute As Action(Of Object)
    	Private _canExecute As Predicate(Of Object)
    	Private Event CanExecuteChangedInternal As EventHandler
    
    	Public Sub New(ByVal execute As Action(Of Object))
    		Me.New(execute, AddressOf DefaultCanExecute)
    	End Sub
    
    	Public Sub New(ByVal exec As Action(Of Object), ByVal canExec As Predicate(Of Object))
    		If exec Is Nothing Then
    			Throw New ArgumentNullException("execute")
    		End If
    		If canExec Is Nothing Then
    			Throw New ArgumentNullException("canExecute")
    		End If
    		_execute = exec
    		_canExecute = canExec
    	End Sub
    
    	Public Custom Event CanExecuteChanged As EventHandler
    		AddHandler(ByVal value As EventHandler)
    			AddHandler CanExecuteChangedInternal, value
    		End AddHandler
    		RemoveHandler(ByVal value As EventHandler)
    			RemoveHandler CanExecuteChangedInternal, value
    		End RemoveHandler
    		RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
    			RaiseEvent CanExecuteChangedInternal(sender, e)
    		End RaiseEvent
    	End Event
    
    	Public Function CanExecute(ByVal param As Object) As Boolean
    		Return _canExecute IsNot Nothing AndAlso canExecute(param)
    	End Function
    
    	Public Sub Execute(ByVal param As Object)
    		execute(param)
    	End Sub
    
    	Public Sub OnCanExecuteChanged()
    		'referencing the hidden "Event" field of the CanExecuteChangedInternal event:
    		Dim handler As EventHandler = CanExecuteChangedInternalEvent
    		If handler IsNot Nothing Then
    			handler.Invoke(Me, EventArgs.Empty)
    		End If
    	End Sub
    
    	Public Sub Destroy()
    		_canExecute = Function(underscore) False
    		Me._execute = Sub(underscore)
    			Return
    		End Sub
    	End Sub
    
    	Private Shared Function DefaultCanExecute(ByVal param As Object) As Boolean
    		Return True
    	End Function
    End Class
