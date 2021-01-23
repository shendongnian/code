    public module ExceptionExtensions
    <DebuggerStepThrough>
    <Extension>
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public Function ToEnglish(Of T As System.Exception)(ByVal ex As T) As String
        Dim oldCI As CultureInfo = Thread.CurrentThread.CurrentUICulture
        Dim exEng As System.Exception = Nothing
        Task.Factory.StartNew(Sub()
                                  Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US")
                                  exEng = DirectCast(Activator.CreateInstance(ex.[GetType]), System.Exception)
                                  Thread.CurrentThread.CurrentUICulture = oldCI
                              End Sub,
                              TaskCreationOptions.LongRunning).Wait()
        Return exEng.Message
    End Function
    end module
