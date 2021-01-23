    Public Class ProcessMonitor
        Public Event Started As Action(Of Integer)
        Public Event Stopped As Action(Of Integer)
    
        Public Sub New(interval As Integer)
            Me.interval = interval
            running = Scan()
            timer = New Threading.Timer(AddressOf callback, Nothing, interval, 0)
        End Sub
    
        Private Sub callback(state As Object)
            Dim active As HashSet(Of Integer) = Scan()
            Dim started As IEnumerable(Of Integer) = active.Except(running)
            Dim stopped As IEnumerable(Of Integer) = running.Except(active)
            running = active
            For Each pid As Integer In started
                RaiseEvent started(pid)
            Next
            For Each pid As Integer In stopped
                RaiseEvent stopped(pid)
            Next
            timer.Change(interval, 0)
        End Sub
    
        Private Function Scan() As HashSet(Of Integer)
            Dim ret As New HashSet(Of Integer)
            For Each proc As Process In Process.GetProcesses()
                ret.Add(proc.Id)
            Next
            Return ret
        End Function
    
        Private running As HashSet(Of Integer)
        Private timer As System.Threading.Timer
        Private interval As Integer
    End Class
