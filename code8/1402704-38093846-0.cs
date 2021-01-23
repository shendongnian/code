    <ScriptService()>
    Public Class WebService1
        Inherits System.Web.Services.WebService
    
        <WebMethod()> _
        <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
        Public Function wwww(ByVal id As String) As String
            Return id & "AAA"
        End Function
    
    End Class
