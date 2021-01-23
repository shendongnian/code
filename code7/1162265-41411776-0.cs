        Try
            Dim Processes() As Process = Process.GetProcessesByName("explorer")
            For Each Process As Process In Processes
                Process.Kill()
            Next
        Catch ex As Exception
        End Try
