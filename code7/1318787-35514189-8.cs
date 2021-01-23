    Public Class FilteredRunner
        Delegate Sub VoidCode()
    
        Private Shared Function FilterAction(x As Exception) As Boolean
            If TypeOf x Is NullReferenceException Then
                Environment.FailFast("Abort program! Investigate Bug via crash dump!", x)
            End If
            ' Never handle here:'
            Return False
        End Function
    
        Public Shared Sub RunFiltered(code As VoidCode)
            Try
                code.Invoke()
            Catch ex As Exception When FilterAction(ex)
                Throw New InvalidProgramException("Unreachable!", ex)
            End Try
        End Sub
    
    End Class
