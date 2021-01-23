    Imports Microsoft.VisualBasic.ApplicationServices
    Namespace My
        Partial Friend Class MyApplication
            ''' <summary>
            ''' Indicates if we are running under the IDE or not
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public ReadOnly Property RunningUnderDebugger() As Boolean
                Get
                    Return System.Diagnostics.Debugger.IsAttached
                End Get
            End Property
            Private mUnhandledExceptionsFileName As String
            Public Property UnhandledExceptionsFileName() As String
                Get
                    Return mUnhandledExceptionsFileName
                End Get
                Set(ByVal value As String)
                    mUnhandledExceptionsFileName = value
                End Set
            End Property
            Private mExceptionDialogIcon As Icon
            ''' <summary>
            ''' Specifically used to set the exception dialog's icon
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property ExceptionDialogIcon() As Icon
                Get
                    Return mExceptionDialogIcon
                End Get
                Set(ByVal value As Icon)
                    mExceptionDialogIcon = value
                End Set
            End Property
    
            Private mContinueAfterException As Boolean
            ''' <summary>
            ''' Determine if this app can stay open after an unhandled
            ''' exception has been thrown.
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks>
            ''' Not practical in most circumstances as we usually
            ''' do not know how to hangle unhandled exceptions and
            ''' leaving an app open will not be wise.
            ''' </remarks>
            Public Property ContinueAfterException() As Boolean
                Get
                    Return Not mContinueAfterException
                End Get
                Set(ByVal value As Boolean)
                    mContinueAfterException = value
                End Set
            End Property
            ''' <summary>
            ''' Displays a user friendly message in regards to the 
            ''' unhandled exception.
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <param name="e"></param>
            ''' <remarks>
            ''' It would be wise to also write to a log file etc.
            ''' 
            ''' WARNING 
            ''' If you use code prone to errors in here then you will not 
            ''' be very happy so test test test before implementing.
            ''' </remarks>
            Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
    
                If String.IsNullOrEmpty(mUnhandledExceptionsFileName) Then
                    mUnhandledExceptionsFileName = "unHandledExceptions.xml"
                End If
    
                Dim Doc As New XDocument
    
                If IO.File.Exists(My.Application.UnhandledExceptionsFileName) Then
                    Doc = XDocument.Load(My.Application.UnhandledExceptionsFileName)
                Else
                    Doc = XDocument.Parse("<?xml version=""1.0"" encoding=""utf-8""?><Exceptions></Exceptions>")
                End If
    
                Dim Content = Doc.<Exceptions>(0)
                Dim StackTraceText As String = e.Exception.StackTrace.ToString
    
                Content.Add(
                <Exception>
                    <Date_Time><%= Now.ToString("MM/dd/yyyy HH:mm") %></Date_Time>
                    <Message><%= e.Exception.Message %></Message>
                    <StackTrace><%= Environment.NewLine %>
                        <%= StackTraceText %><%= Environment.NewLine %>
                    </StackTrace>
                </Exception>)
    
                Content.Save(My.Application.UnhandledExceptionsFileName)
    
                ' here I am using a form setup specifically to show exceptions
                'Dim f As New frmExceptionDialog
                'f.InBoundException = e.Exception
                'f.Message = String.Format("Exception has been recorded to [{0}]", My.Application.UnhandledExceptionsFileName)
                'f.Header = "Unhandled exception"
    
    
                'Try
                '    f.ShowDialog()
                'Finally
                '    f.Dispose()
                'End Try
    
                MessageBox.Show("Encountered an exception" & Environment.NewLine & e.Exception.Message)
    
    
                e.ExitApplication = Me.ContinueAfterException
    
                If Me.ContinueAfterException Then
                    Me.ContinueAfterException = False
                End If
    
            End Sub
        End Class
    End Namespace
