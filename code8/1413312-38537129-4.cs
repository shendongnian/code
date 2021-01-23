    Public Class ZipZapSettingsProvider
        Inherits SettingsProvider
    
        ' data we store for each item
        Friend Structure SettingsItem
            Friend Name As String
            Friend SerializeAs As String
            Friend Value As String
        End Structure
    
        ' used in the XML
        Const ITEMNAME As String = "name"
        Const SERIALIZE_AS As String = "serializeAs"
        Const CONFIG As String = "configuration"
        Const USER_SETTINGS As String = "userSettings"
        Const SETTING As String = "setting"
    
        Private UserConfigFilePath As String = ""
        Private myCol As Dictionary(Of String, SettingsItem)
    
        Public Sub New()
            myCol = New Dictionary(Of String, SettingsItem)
    
            Dim asm = Assembly.GetExecutingAssembly()
            Dim verInfo = FileVersionInfo.GetVersionInfo(asm.Location)
            Dim Company = verInfo.CompanyName
            ' product name may have no relation to file name...
            Dim ProdName = verInfo.ProductName
    
            ' use this for assembly file name:
            Dim modName = Path.GetFileNameWithoutExtension(asm.ManifestModule.Name)
            ' can get this in bits and pieces from FileVersionInfo
            Dim ver = asm.GetName.Version
    
            ' where the file will be saved to
            ' Most people might want to use: `GetFolderPath(SpecialFolder.LocalApplicationData)`
            '    for the base to map to ...UserName\AppData\Local
            UserConfigFilePath = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData),
                                          Company, ProdName,
                                          ver.ToString(), "user.config")
        End Sub
    
        ' boilerplate
        Public Overrides Property ApplicationName As String
            Get
                Return Assembly.GetExecutingAssembly().ManifestModule.Name
            End Get
            Set(value As String)
    
            End Set
        End Property
    
        ' boilerplate
        Public Overrides Sub Initialize(name As String, config As Specialized.NameValueCollection)
            MyBase.Initialize(ApplicationName, config)
        End Sub
    
        ' conversion helper in place of a 'Select Case GetType(foo)'
        Private Shared Conversion As Func(Of Object, Object)
    
        Public Overrides Function GetPropertyValues(context As SettingsContext,
                      collection As SettingsPropertyCollection) As SettingsPropertyValueCollection
            ' basically, create a Dictionary entry for each setting,
            ' store the converted value to it
            ' Add an entry when something is added
            '
            ' This is called the first time you get a setting value
            If myCol.Count = 0 Then
                LoadData()
            End If
    
            Dim theSettings = New SettingsPropertyValueCollection()
            Dim tValue As String = ""
    
            ' SettingsPropertyCollection is like a Shopping list
            ' of props that VS/VB wants the value for
            For Each setItem As SettingsProperty In collection
                Dim value As New SettingsPropertyValue(setItem)
                value.IsDirty = False
    
                If myCol.ContainsKey(setItem.Name) Then
                    value.SerializedValue = myCol(setItem.Name)
                    tValue = myCol(setItem.Name).Value
                Else
                    value.SerializedValue = setItem.DefaultValue
                    tValue = setItem.DefaultValue.ToString
                End If
                ' not used - for illustration
                Dim roamer = IsRoamer(setItem)
    
                ' ToDo: Enums will need an extra step
                Conversion = Function(v) TypeDescriptor.
                                        GetConverter(setItem.PropertyType).
                                        ConvertFromInvariantString(v.ToString())
    
                value.PropertyValue = Conversion(tValue)
                theSettings.Add(value)
            Next
    
            Return theSettings
        End Function
    
        Public Overrides Sub SetPropertyValues(context As SettingsContext,
                                               collection As SettingsPropertyValueCollection)
            ' this is not called when you set a new value
            ' rather, NET has one or more changed values that
            ' need to be saved, so be sure to save them to disk
            For Each item As SettingsPropertyValue In collection
                Dim sItem = New SettingsItem() With {
                                    .Name = item.Name,
                                    .Value = item.SerializedValue.ToString(),
                                    .SerializeAs = item.Property.SerializeAs.ToString()
                                }
    
                Dim roamer = IsRoamer(item.Property)
    
                If myCol.ContainsKey(sItem.Name) Then
                    myCol(sItem.Name) = sItem
                Else
                    myCol.Add(sItem.Name, sItem)
                End If
            Next
    
            SaveData()
        End Sub
    
        ' detect if a setting is tagged as Roaming
        Private Function IsRoamer(prop As SettingsProperty) As Boolean
            Dim r = prop.Attributes.
                        Cast(Of DictionaryEntry).
                        FirstOrDefault(Function(q) TypeOf q.Value Is SettingsManageabilityAttribute)
    
            Return r.Key IsNot Nothing
        End Function
    
        Private Sub LoadData()
            ' load from disk
            If File.Exists(UserConfigFilePath) = False Then
                CreateNewConfig()
            End If
    
            Dim cfg = XDocument.Load(UserConfigFilePath)
            Dim items As IEnumerable(Of XElement)
    
            ' ToDo(?): check if any of these are null (?)
            items = cfg.Element(CONFIG).Element(USER_SETTINGS).
                                Element(GetType(My.MySettings).FullName).
                                Elements(SETTING)
    
            Dim item As SettingsItem
            For Each xitem As XElement In items
    
                item = New SettingsItem With {.Name = xitem.Attribute(ITEMNAME).Value,
                                              .SerializeAs = xitem.Attribute(SERIALIZE_AS).Value}
                item.Value = xitem.Value
                myCol.Add(item.Name, item)
            Next
    
        End Sub
    
        Private Sub SaveData()
            ' write to disk
            Dim xDoc = XDocument.Load(UserConfigFilePath)
    
            Dim section = xDoc.Element(CONFIG).
                                Element(USER_SETTINGS).
                                Element(GetType(My.MySettings).FullName)
    
            For Each kvp As KeyValuePair(Of String, SettingsItem) In myCol
                Dim item = section.Elements().
                        FirstOrDefault(Function(q) q.Attribute(ITEMNAME).Value = kvp.Key)
    
                If item Is Nothing Then
                    ' found a new item
                    Dim newItem = New XElement(SETTING)
                    newItem.Add(New XAttribute(ITEMNAME, kvp.Value.Name))
                    newItem.Add(New XAttribute(SERIALIZE_AS, kvp.Value.SerializeAs))
                    newItem.Value = If(String.IsNullOrEmpty(kvp.Value.Value), "", kvp.Value.Value)
                    section.Add(newItem)
                Else
                    item.Value = If(String.IsNullOrEmpty(kvp.Value.Value), "", kvp.Value.Value)
                End If
    
            Next
            xDoc.Save(UserConfigFilePath)
    
        End Sub
    
        Private Sub CreateNewConfig()
            Dim fpath = Path.GetDirectoryName(UserConfigFilePath)
            Directory.CreateDirectory(fpath)
    
            Dim xdoc = New XDocument
            xdoc.Declaration = New XDeclaration("1.0", "utf-8", "true")
            Dim cfg = New XElement(CONFIG)
            Dim settings = New XElement(USER_SETTINGS)
            Dim level = New XElement(GetType(My.MySettings).FullName)
            settings.Add(level)
            cfg.Add(settings)
            xdoc.Add(cfg)
    
            xdoc.Save(UserConfigFilePath)
        End Sub
    
    End Class
