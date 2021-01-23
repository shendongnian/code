    Public Shared Sub DiagnosticEventHandler(sender As Object, e As EventArgs)
        'heuristic disclosing of method related to event name
        Dim maxAttemps As Integer = 10
        Dim attempt As Integer = 1
        Dim stackTrace As New StackTrace()
        Do While attempt <= maxAttemps
            Dim methodName As String = stackTrace.GetFrame(attempt).GetMethod().Name
            attempt += 1
            If Not methodName.StartsWith("On") Then Continue Do
            Debug.Print(methodName)
            Return
        Loop
        Debug.Print(String.Join("<", stackTrace.GetFrames().Take(maxAttemps).Select(Of String)(Function(sf) sf.GetMethod.Name).ToArray()))
    End Sub
