        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Microsoft.Win32.SystemEvents.PowerModeChanged, AddressOf SysSuspend
        AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf SysLogOff
        AddHandler Microsoft.Win32.SystemEvents.SessionSwitch, AddressOf SysSwitch
        AddHandler Microsoft.Win32.SystemEvents.SessionEnded, AddressOf SysLoggedOff
        AddHandler Microsoft.Win32.SystemEvents.PowerModeChanged, AddressOf StatusChange
    End Sub
    Public Sub SysLogOff(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionEndingEventArgs)
        If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
            MessageBox.Show("user logging off")
        ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
            MessageBox.Show("system is shutting down")
        End If
    End Sub
    Public Sub SysLoggedOff(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionEndedEventArgs)
        If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
            MessageBox.Show("user logged off")
        ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
            MessageBox.Show("system has shut down")
        End If
    End Sub
    Public Sub SysSwitch(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionSwitchEventArgs)
        If e.Reason = Microsoft.Win32.SessionSwitchReason.ConsoleConnect Then
            MessageBox.Show("Console connect")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.ConsoleDisconnect Then
            MessageBox.Show("Console disconnect")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.RemoteConnect Then
            MessageBox.Show("Remote Connect")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.RemoteDisconnect Then
            MessageBox.Show("Remote Disconnect")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLock Then
            MessageBox.Show("Session Lock")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLogoff Then
            MessageBox.Show("Session Logoff")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLogon Then
            MessageBox.Show("Session Logon")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionRemoteControl Then
            MessageBox.Show("Session Remote Control")
        ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionUnlock Then
            MessageBox.Show("Session Unlock", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End If
    End Sub
    Public Sub SysSuspend(ByVal sender As Object, ByVal e As Microsoft.Win32.PowerModeChangedEventArgs)
        If e.Mode = Microsoft.Win32.PowerModes.Resume Then
            MessageBox.Show("system is resuming")
        ElseIf e.Mode = Microsoft.Win32.PowerModes.Suspend Then
            MessageBox.Show("system being suspended")
        ElseIf e.Mode = Microsoft.Win32.PowerModes.StatusChange Then
            MessageBox.Show("system has a status change")
        End If
    End Sub
    Public Sub StatusChange(ByVal sender As Object, ByVal e As Microsoft.Win32.PowerModeChangedEventArgs)
        If e.Mode = Microsoft.Win32.PowerModes.StatusChange Then
            MessageBox.Show("Battery status has changed")
        End If   
    End Sub
