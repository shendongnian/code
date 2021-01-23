    <%@ WebHandler Language="VB" Class="APICaller" %>
    Imports System
    Imports System.Net
    Imports System.IO
    Public Class APICaller : Implements IHttpHandler
	Private _DestinationEndpoint As String = ""
	
	Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
		If context.Request("endpoint") <> "" And (context.Request("debug") = "" Or context.Request("debug") = "false") Then
			Try
				_DestinationEndpoint = HttpContext.Current.Server.UrlDecode(context.Request("endpoint")).ToString
				If (_DestinationEndpoint.IndexOf("http://") = -1) Then
					_DestinationEndpoint = "http://" & _DestinationEndpoint
				End If
		
				Dim newRequest As HttpWebRequest = WebRequest.Create(_DestinationEndpoint)
				newRequest.ContentType = context.Request.ContentType
				newRequest.Method = context.Request.HttpMethod
		
				For Each hdr As String In context.Request.Headers
					Select Case hdr
						Case "Content-Length", "Content-Type", "Expect", "Host", "Connection", "Accept", "User-Agent"
						Case Else
							newRequest.Headers.Add(hdr, context.Request.Headers(hdr))
					End Select
				Next
		
				Dim ms As New MemoryStream()
				HttpContext.Current.Request.InputStream.CopyTo(ms)
				Dim data As Byte() = ms.ToArray()
		
				'If context.Request.RequestType = "POST" Then
				Dim reqStream = newRequest.GetRequestStream()
				reqStream.Write(data, 0, data.Length)
				reqStream.Close()
				'End If
		
				Dim response As HttpWebResponse = DirectCast(newRequest.GetResponse, HttpWebResponse)
		
				Dim responseFromServer As String = "API Error"
				Dim reader As StreamReader = Nothing
				Dim responseStream As Stream = Nothing
				responseStream = response.GetResponseStream()
				reader = New StreamReader(responseStream)
				Dim sb As StringBuilder = New StringBuilder()
				Dim buffer As Char() = New Char(1024 * 8 - 1) {}
				Dim read As Integer = 0
				Do
					read = reader.Read(buffer, 0, buffer.Length)
					sb.Append(New [String](buffer, 0, read))
				Loop While Not reader.EndOfStream
				If reader.EndOfStream Then
					responseFromServer = sb.ToString()
				End If
				response.Close()
				responseStream.Close()
				reader.Close()
				HttpContext.Current.Response.Write(responseFromServer)
			Catch ex As Exception
				HttpContext.Current.Response.Write(ex.Message)
			End Try
		Else
			HttpContext.Current.Response.Write("<h1>Welcome</h1>")
			If context.Request("debug") = True Then
				HttpContext.Current.Response.Write("<ul>")
				For Each hdr As String In context.Request.Headers
					HttpContext.Current.Response.Write("<li>" & hdr & " - " & context.Request.Headers(hdr) & "</li>")
				Next
				HttpContext.Current.Response.Write("<li>-- ContentType = " & HttpContext.Current.Request.ContentType & "</li>")
				HttpContext.Current.Response.Write("</ul>")
			End If
		End If
	End Sub
 
	Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
		Get
			Return False
		End Get
	End Property
    End Class
