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
        'whatever
    End Sub
