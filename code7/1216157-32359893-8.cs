    Public Shared Sub DiagnosticEventHandler(sender As Object, e As EventArgs)
        'heuristic disclosing of method related to event name
        Dim maxAttempts As Integer = 15
        Dim attempt As Integer = 1
        Dim stackTrace As New StackTrace()
        Do While attempt <= maxAttempts
            Dim methodName As String = stackTrace.GetFrame(attempt).GetMethod().Name
            attempt += 1
            If Not methodName.StartsWith("On") Then Continue Do
            Debug.Print(String.Join(" > ", stackTrace.GetFrames().Take(attempt).Skip(1).Select(Of String)(Function(sf) sf.GetMethod.Name).Reverse().ToArray()))
            Return
        Loop
        Debug.Print(String.Join(" > ", stackTrace.GetFrames().Take(maxAttempts).Select(Of String)(Function(sf) sf.GetMethod.Name).Reverse().ToArray()))
    End Sub
