    Public Sub New()
        InitializeComponent() ' needed only in Form class
        BindHandlers(TextBox1) ' this is our binding
    End Sub
    Public Sub BindHandlers(c As Control)
        Dim handler As MethodInfo = Me.GetType().GetMethod(NameOf(DiagnosticEventHandler))
        For Each ei In c.GetType().GetEvents()
            ei.AddEventHandler(c, [Delegate].CreateDelegate(ei.EventHandlerType, handler))
        Next
    End Sub
    Public Shared Sub DiagnosticEventHandler(sender As Object, e As EventArgs)
        'heuristic disclosing of event name - bonus for you who read until here :)
        Dim methodName As String = New StackTrace().GetFrame(1).GetMethod().Name
        If methodName = "Invoke" Then methodName = New StackTrace().GetFrame(2).GetMethod().Name
        Debug.Print(methodName)
    End Sub
