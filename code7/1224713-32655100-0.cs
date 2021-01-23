    Public Shared Function GetAppConfigSetting(Of T)(ByVal sectionGroupName As String,
                                                     ByVal sectionName As String,
                                                     ByVal elementName As String,
                                                     ByVal propertyName As String,
                                                     Optional ByVal exePath As String = "") As T
        Dim appConfig As Configuration
        Dim group As ConfigurationSectionGroup
        Dim section As ConfigurationSection
        Dim sectionPropInfo As PropertyInformation
        Dim element As ConfigurationElement
        Dim elementPropInfo As PropertyInformation
        If Not String.IsNullOrEmpty(exePath) Then
            appConfig = ConfigurationManager.OpenExeConfiguration(exePath)
        Else
            appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        End If
        group = appConfig.GetSectionGroup(sectionGroupName)
        If group Is Nothing Then
            Return Nothing
        End If
        section = group.Sections(sectionName)
        If section Is Nothing Then
            Return Nothing
        End If
        sectionPropInfo = section.ElementInformation.Properties(elementName)
        If sectionPropInfo Is Nothing Then
            Return Nothing
        End If
        element = DirectCast(sectionPropInfo.Value, ConfigurationElement)
        If element Is Nothing Then
            Return Nothing
        End If
        elementPropInfo = element.ElementInformation.Properties(propertyName)
        If elementPropInfo Is Nothing Then
            Return Nothing
        End If
        Return DirectCast(elementPropInfo.Value, T)
    End Function
