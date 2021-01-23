    Imports System
    Imports System.Web
    Imports System.Drawing
    Imports System.Drawing.Drawing2D
    
    Public Class CropKGNewsCrop : Implements IHttpHandler
        
        Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
            Dim imgUrl As String = context.Server.MapPath("~/_fhadm/" & context.Request("imgUrl"))
            Dim imgInitW As Decimal = context.Request("imgInitW")
            Dim imgInitH As Decimal = context.Request("imgInitH")
            Dim imgW As Decimal = context.Request("imgW")
            Dim imgH As Decimal = context.Request("imgH")
            Dim imgY1 As Decimal = context.Request("imgY1")
            Dim imgX1 As Decimal = context.Request("imgX1")
            Dim cropW As Decimal = context.Request("cropW")
            Dim cropH As Decimal = context.Request("cropH")
          
            Using bmp = New Bitmap(imgUrl)
                Using newbmp As Bitmap = resizeImage(bmp, New Size With {.Height = imgH, .Width = imgW})
                    Using bmpcrop As Bitmap = newbmp.Clone(New Drawing.Rectangle With {.Height = cropH, .Width = cropW, .X = imgX1, .Y = imgY1}, newbmp.PixelFormat)
                        Dim croppedFilename As String = "cropped_" & System.IO.Path.GetRandomFileName() & System.IO.Path.GetExtension(imgUrl)
                        Dim croppedUrl As String = AdminTempNewsPic & croppedFilename
                        bmpcrop.Save(croppedUrl)
                        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(New successmsg With {.status = "success", .url = "img/_temp/" & croppedFilename}))
                    End Using
                End Using
            End Using
        End Sub
        
    
        Private Shared Function resizeImage(imgToResize As Image, size As Size) As Image
            Dim sourceWidth As Integer = imgToResize.Width
            Dim sourceHeight As Integer = imgToResize.Height
    
            Dim nPercent As Single = 0
            Dim nPercentW As Single = 0
            Dim nPercentH As Single = 0
    
            nPercentW = (CSng(size.Width) / CSng(sourceWidth))
            nPercentH = (CSng(size.Height) / CSng(sourceHeight))
    
            If nPercentH < nPercentW Then
                nPercent = nPercentH
            Else
                nPercent = nPercentW
            End If
    
            Dim destWidth As Integer = CInt(sourceWidth * nPercent)
            Dim destHeight As Integer = CInt(sourceHeight * nPercent)
    
            Dim b As New Bitmap(destWidth, destHeight)
            Dim g As Graphics = Graphics.FromImage(DirectCast(b, Image))
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
    
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight)
            g.Dispose()
    
            Return DirectCast(b, Image)
        End Function
        
     
        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    
    End Class
    
    Public Class successmsg
        Public status As String
        Public url As String
    End Class
