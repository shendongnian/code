    Imports System
    Imports System.Web
    Imports Newtonsoft.Json
    
    Public Class CropKGNews : Implements IHttpHandler
        
        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            Dim up As HttpPostedFile = context.Request.Files(0)
            Dim upimg As System.Drawing.Image = System.Drawing.Image.FromStream(up.InputStream)
            
            Dim newFilename As String = System.IO.Path.GetRandomFileName() & System.IO.Path.GetExtension(up.FileName)
            up.SaveAs(MySettings.Constants.Folders.AdminTempPics & newFilename)
            
            Dim s As New successmsg With {.status = "success", .url = "img/_temp/" & newFilename, .width = upimg.Width, .height = upimg.Height}
            
            context.Response.Write(JsonConvert.SerializeObject(s))
        End Sub
     
        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    
    End Class
    
    Public Class successmsg
        Public status As String
        Public url As String
        Public width As Integer
        Public height As Integer
    End Class
