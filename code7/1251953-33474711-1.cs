    Module Module1
        Sub Main()
            Dim monitor As New ProcessMonitor(100)
            AddHandler monitor.Started, AddressOf Started
            AddHandler monitor.Stopped, AddressOf Stopped
            Console.ReadLine()
        End Sub
        Sub Started(pid As Integer)
            Console.WriteLine("Started: {0}", Process.GetProcessById(pid).ProcessName)
        End Sub
        Sub Stopped(pid As Integer)
            Console.WriteLine("Stopped: {0}", pid)
        End Sub
    End Module
