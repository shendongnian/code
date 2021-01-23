    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Converts the message of a <see cref="System.Exception"/> to English language.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="ex">
    ''' An <see cref="System.Exception"/> that contains an exception message in a non-english language.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <returns>
    ''' The exception message in English language.
    ''' </returns>
    ''' ----------------------------------------------------------------------------------------------------
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
