    Public Class CustomSettingsProvider
        Inherits SettingsProvider
    
        ' data we store for each item
        Friend Class SettingsItem
            Friend Name As String
            'Friend SerializeAs As String           ' not needed
            Friend Value As String
            Friend Roamer As Boolean
            Friend Remove As Boolean                ' mutable
            'Friend VerString As String             ' ToDo (?)
        End Class
    
        ' used for node name
        Private thisMachine As String
    
        ' loaded XML config
        'Private xDoc As XDocument
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
            ' dont use FileVersionInfo;
            ' may want to omit the last element
            'Dim ver = asm.GetName.Version
    
    
            '  uses `SpecialFolder.ApplicationData`
            '    since it will store Local and Roaming val;ues
            UserConfigFilePath = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData),
                                          Company, modName,
                                           "user.config")
    
            ' "CFG" prefix prevents illegal XML, 
            '    the FOO suffix is to emulate a different machine
            thisMachine = "CFG" & My.Computer.Name & "_FOO"
    
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
            Dim names As List(Of String) = myCol.Keys.ToList
            Dim sItem As SettingsItem
    
            For Each item As SettingsPropertyValue In collection
                sItem = New SettingsItem() With {
                                    .Name = item.Name,
                                    .Value = item.SerializedValue.ToString(),
                                    .Roamer = IsRoamer(item.Property)
                                }
                '.SerializeAs = item.Property.SerializeAs.ToString(),
    
                names.Remove(item.Name)
                If myCol.ContainsKey(sItem.Name) Then
                    myCol(sItem.Name) = sItem
                Else
                    myCol.Add(sItem.Name, sItem)
                End If
            Next
    
            ' flag any no longer used
            ' do not use when specifying a provider per-setting!
            For Each s As String In names
                myCol(s).Remove = True
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
    
            Dim xDoc = XDocument.Load(UserConfigFilePath)
            Dim items As IEnumerable(Of XElement)
            Dim item As SettingsItem
    
            items = xDoc.Element(CONFIG).
                                 Element(COMMON).
                                 Elements(SETTING)
    
            ' load the common settings
            For Each xitem As XElement In items
                item = New SettingsItem With {.Name = xitem.Attribute(ITEMNAME).Value,
                                              .Roamer = False}
                '.SerializeAs = xitem.Attribute(SERIALIZE_AS).Value,
    
                item.Value = xitem.Value
                myCol.Add(item.Name, item)
            Next
    
            ' First check if there is a machine node
            If xDoc.Element(CONFIG).Element(thisMachine) Is Nothing Then
                ' nope, add one
                xDoc.Element(CONFIG).Add(New XElement(thisMachine))
            End If
            items = xDoc.Element(CONFIG).
                                Element(thisMachine).
                                Elements(SETTING)
    
            For Each xitem As XElement In items
                item = New SettingsItem With {.Name = xitem.Attribute(ITEMNAME).Value,
                                              .Roamer = True}
                '.SerializeAs = xitem.Attribute(SERIALIZE_AS).Value,
    
                item.Value = xitem.Value
                myCol.Add(item.Name, item)
            Next
            ' we may have changed the XDOC, by adding a machine node 
            ' save the file
            xDoc.Save(UserConfigFilePath)
        End Sub
    
        Private Sub SaveData()
            ' write to disk
    
            Dim xDoc = XDocument.Load(UserConfigFilePath)
            Dim roamers = xDoc.Element(CONFIG).
                               Element(thisMachine)
    
            Dim locals = xDoc.Element(CONFIG).
                              Element(COMMON)
    
            Dim item As XElement
            Dim section As XElement
    
            For Each kvp As KeyValuePair(Of String, SettingsItem) In myCol
                If kvp.Value.Roamer Then
                    section = roamers
                Else
                    section = locals
                End If
    
                item = section.Elements().
                            FirstOrDefault(Function(q) q.Attribute(ITEMNAME).Value = kvp.Key)
    
                If item Is Nothing Then
                    ' found a new item
                    Dim newItem = New XElement(SETTING)
                    newItem.Add(New XAttribute(ITEMNAME, kvp.Value.Name))
                    'newItem.Add(New XAttribute(SERIALIZE_AS, kvp.Value.SerializeAs))
                    newItem.Value = If(String.IsNullOrEmpty(kvp.Value.Value), "", kvp.Value.Value)
                    section.Add(newItem)
                Else
                    If kvp.Value.Remove Then
                        item.Remove()
                    Else
                        item.Value = If(String.IsNullOrEmpty(kvp.Value.Value), "", kvp.Value.Value)
                    End If
                End If
    
            Next
            xDoc.Save(UserConfigFilePath)
    
        End Sub
    
        ' used in the XML
        Const CONFIG As String = "configuration"
        Const SETTING As String = "setting"
        Const COMMON As String = "CommonShared"
        Const ITEMNAME As String = "name"
        'Const SERIALIZE_AS As String = "serializeAs"
    
        ' http://stackoverflow.com/a/11398536
        Private Sub CreateNewConfig()
            Dim fpath = Path.GetDirectoryName(UserConfigFilePath)
            Directory.CreateDirectory(fpath)
    
            Dim xDoc = New XDocument
            xDoc.Declaration = New XDeclaration("1.0", "utf-8", "true")
            Dim cfg = New XElement(CONFIG)
    
            cfg.Add(New XElement(COMMON))
            cfg.Add(New XElement(thisMachine))
    
            xDoc.Add(cfg)
            xDoc.Save(UserConfigFilePath)
        End Sub
    
    End Class
