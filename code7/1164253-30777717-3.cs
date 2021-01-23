    Public Shared Sub MemoryBarrier()
        Dim useless As Integer = 0
        Dim value As Integer = Volatile.Read(useless)
        Volatile.Write(useless, value)
    End Sub
