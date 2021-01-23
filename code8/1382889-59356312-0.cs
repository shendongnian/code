    Private _uniqueEventName As String
    Private _uniqueMutexName As String
    Private _eventWaitHandle As EventWaitHandle
    Private _mutex As Mutex
    Private Sub ensureSingleInstance()
        _uniqueEventName = "{0ae64101-e630-4221-bf10-123fdddd5ab2}" + Assembly.GetEntryAssembly().GetName().Name
        _uniqueMutexName = "{03169a07-793b-48c6-8ceb-1232388cb69a}" + Assembly.GetEntryAssembly().GetName().Name
        Dim isOwned As Boolean
        _mutex = New Mutex(True, _uniqueMutexName, isOwned)
        _eventWaitHandle = New EventWaitHandle(False, EventResetMode.AutoReset, _uniqueEventName)
        GC.KeepAlive(_mutex)
        If isOwned Then
            Dim thread As Thread = New Thread(
                                   Sub()
                                       While _eventWaitHandle.WaitOne()
                                           Application.Dispatcher.BeginInvoke(
                                               Sub()
                                                   ' ****************************************************
                                                   ' READ AND PROCESS THE ARGUMENTS FROM C:\MYAPPARGS.TXT
                                                   ' ****************************************************
                                                   If Not Application.MainWindow Is Nothing Then
                                                       _loggingDAL.Log("Activating main window")
                                                       If (Application.MainWindow.WindowState = WindowState.Minimized Or Application.MainWindow.Visibility = Visibility.Hidden) Then
                                                           Application.MainWindow.Show()
                                                           Application.MainWindow.WindowState = WindowState.Normal
                                                       End If
                                                       Application.MainWindow.Activate()
                                                       Dim topMost As Boolean = Application.MainWindow.Topmost
                                                       Application.MainWindow.Topmost = True
                                                       Application.MainWindow.Topmost = topMost
                                                       Application.MainWindow.Focus()
                                                   End If
                                               End Sub)
                                       End While
                                   End Sub)
            thread.IsBackground = True
            thread.Start()
        Else
            _loggingDAL.Log("There is already an instance running -> switching and quitting")
            ' ***************************************
            ' WRITE THE ARGUMENTS TO C:\MYAPPARGS.TXT
            ' ***************************************
            _eventWaitHandle.Set()
            Application.Shutdown()
        End If
    End Sub
