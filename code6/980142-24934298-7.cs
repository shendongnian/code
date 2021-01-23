    Module Program
    Sub Main()
        Dim test As New Test()
        For i As Integer = 0 To 2
            Try
                test.ThrowSomeException(i)
            Catch exception As Exception
                Console.WriteLine(exception)
            End Try
        Next
    End Sub
    End Module
    Public Class Test
    Public Sub ThrowSomeException(arg As Integer)
        Console.WriteLine("arg = {0}", arg)
        Select Case arg
            Case 0
                If True Then
                    Dim ex As New Exception("Line number = 22")
                    Throw ex
                End If
            Case 1
                If True Then
                    Dim ex As New Exception("Line number = 27")
                    Throw ex
                End If
            Case Else
                If True Then
                    Dim ex As New Exception("Line number = 32")
                    Throw ex
                End If
        End Select
    End Sub
    End Class
