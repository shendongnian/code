    <%@ WebHandler Language="VB" Class="Upload" %>
    
    Imports System
    Imports System.Web
    Imports System.IO
    
    Public Class Upload : Implements IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    
        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            Try
                UploadFile(context)
                context.Response.Write("{""success"":true, ""msg"":""upload successfully!""}")
            Catch ex As Exception
                context.Response.Write("{""error"":""An error message""}")
            End Try
        End Sub
    
        Private Sub UploadFile(ByVal context As HttpContext)
            For Each s As String In context.Request.Files
                Dim file = context.Request.Files(s)
                Dim fileName = file.FileName
                Dim fileExtension = file.ContentType
    
                If String.IsNullOrEmpty(fileName) Then
                    'TODO: Warning!!! continue If                
                    Throw New System.Exception("File null or empty")
                End If
    
                Dim pathToSave = "C:\TEMP\" + fileName ' Or -> (HttpContext.Current.Server.MapPath(tempPath) + ("\" + fileName))
                file.SaveAs(pathToSave)
    
                ' *** Database operations here ***
                '=================================
                ' Dim userid As String = HttpContext.Current.Session("UserID").ToString()
                ' RegisterFileToDatabase(userid, fileName)
                ' ...
                ' ...
            Next
        End Sub
    
        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    
    End Class
