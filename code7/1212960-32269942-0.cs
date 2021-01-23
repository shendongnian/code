    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim processes As Process() = Process.GetProcessesByName("notepad")
        For Each p As Process In processes
            Dim handle As IntPtr = p.MainWindowHandle
            Dim Rect As New RECT()
            If GetWindowRect(handle, Rect) Then
                MoveWindow(handle, (My.Computer.Screen.WorkingArea.Width - 1280) \ 2, (My.Computer.Screen.WorkingArea.Height - 720) \ 2, 1280, 720, True)
            End If
        Next
    End Sub
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function GetWindowRect(hWnd As IntPtr, ByRef Rect As RECT) As Boolean
    End Function
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function MoveWindow(hWnd As IntPtr, X As Integer, Y As Integer, Width As Integer, Height As Integer, Repaint As Boolean) As Boolean
    End Function
