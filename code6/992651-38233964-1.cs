    Private Sub Wmi_Connect(ByRef wmiScope As Management.ManagementScope)
        Try
            wmiScope.Connect()
        Catch ex As System.Runtime.InteropServices.COMException
        End Try
    End Sub
