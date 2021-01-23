    Public Class myDevice
    Private Device As HidDevice
    Private isConnected as Boolean
    Public Sub Close()
        If Not Device Is Nothing Then
            Device.CloseDevice()
            Device.MonitorDeviceEvents = False
        End If
        isConnected = False
    End Sub
    Sub OnReport(Report As HidReport)
        If isConnected = False Then
            Device.Dispose()
            Device = Nothing
            Return
        End If
        ' Do stuff with the data
        ' ...
        ' ...
        ' Wait for more data.
        Device.ReadReport(AddressOf OnReport)
    End Sub
    End Class
