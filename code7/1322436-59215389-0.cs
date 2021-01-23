    Imports System.Xml
    Imports System.Configuration
    Public Class XConfiguration
        Private ConfigurationFilePath As String
        Private XmlDoc As XmlDocument
        Public Sub New()
            ConfigurationFilePath = Web.HttpContext.Current.Server.MapPath("/") & "web.config"
            XmlDoc = New XmlDocument() With {.PreserveWhitespace = True}
            Try
                XmlDoc.Load(ConfigurationFilePath)
            Catch e As System.IO.FileNotFoundException
                Throw New Exception("No configuration file found.", e)
            End Try
        End Sub
        Public Sub WriteConnectionString(ByVal Name As String, ByVal ConnectionString As String,Optional ByVal SaveImmediately As Boolean = False)
            Dim NodeConnectionStrings As XmlNode = XmlDoc.SelectSingleNode("//connectionStrings")
            If NodeConnectionStrings Is Nothing Then Throw New InvalidOperationException("connectionStrings section not found in config file.")
    
            Dim ElemAdd As XmlElement = CType(NodeConnectionStrings.SelectSingleNode(String.Format("//add[@name='{0}']", Name)), XmlElement)
    
            If ElemAdd IsNot Nothing Then
                ElemAdd.SetAttribute("connectionString", ConnectionString)
            Else
                ElemAdd = XmlDoc.CreateElement("add")
                ElemAdd.SetAttribute("name", Name)
                ElemAdd.SetAttribute("connectionString", ConnectionString)
                NodeConnectionStrings.AppendChild(ElemAdd)
            End If
    
            If SaveImmediately Then Save()
        End Sub
        Public Function ReadSetting(ByVal Key As String) As String
            Return ConfigurationManager.AppSettings(Key)
        End Function
        Public Sub WriteAppSetting(ByVal Key As String, ByVal Value As String, Optional ByVal SaveImmediately As Boolean = False)
            Dim NodeAppSettings As XmlNode = XmlDoc.SelectSingleNode("//appSettings")
            If NodeAppSettings Is Nothing Then Throw New InvalidOperationException("appSettings section not found in config file.")
    
            Dim ElemAdd As XmlElement = CType(NodeAppSettings.SelectSingleNode(String.Format("//add[@key='{0}']", Key)), XmlElement)
    
            If ElemAdd IsNot Nothing Then
                ElemAdd.SetAttribute("value", Value)
            Else
                ElemAdd = XmlDoc.CreateElement("add")
                ElemAdd.SetAttribute("key", Key)
                ElemAdd.SetAttribute("value", Value)
                NodeAppSettings.AppendChild(ElemAdd)
            End If
    
            If SaveImmediately Then Save()
        End Sub
        Public Sub RemoveSetting(ByVal Key As String, Optional ByVal SaveImmediately As Boolean = False)
            Dim NodeAppSettings As XmlNode = XmlDoc.SelectSingleNode("//appSettings")
    
            If NodeAppSettings Is Nothing Then
                Throw New InvalidOperationException("appSettings section not found in config file.")
            Else
                NodeAppSettings.RemoveChild(NodeAppSettings.SelectSingleNode(String.Format("//add[@key='{0}']", Key)))
            End If
    
            If SaveImmediately Then Save()
        End Sub
        Public Sub Save()
            XmlDoc.Save(ConfigurationFilePath)
        End Sub
    End Class
