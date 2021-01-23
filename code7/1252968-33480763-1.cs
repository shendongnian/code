    Imports System.ComponentModel
    Module Module1
        Sub Main()
            Dim backgroundWorker As New MyBackGroundWorker
            backgroundWorker.Dispose()
        End Sub
    End Module
    Class MyBackGroundWorker : Implements IDisposable
        Dim backgroundWorker As New BackgroundWorker
        Sub Dispose() Implements IDisposable.Dispose
            Me.Dispose()
        End Sub
    End Class
