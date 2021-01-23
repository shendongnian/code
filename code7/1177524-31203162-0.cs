    Public Class ApplicationSettings
        Implements IDisposable
        Private ScreenUpdating As Boolean
        Private Events As Boolean
        Private Production As Boolean = True
    
        Public Sub New()
            MyBase.New()
            ScreenUpdating = AddinModule.ExcelApp.ScreenUpdating
            Events = AddinModule.ExcelApp.EnableEvents
        End Sub
    
        Public Sub Dispose() Implements IDisposable.Dispose
            AddinModule.ExcelApp.ScreenUpdating = ScreenUpdating
            AddinModule.ExcelApp.EnableEvents = Events
        End Sub
    End Class
