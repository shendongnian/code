    Dim strPropertyName As String = "OrganizationalIDNumber"
    Dim oContact As New Contact(pExchnageService)
    Dim oOrganizationalIDNumber  As New ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, strPropertyName, MapiPropertyType.Integer)
    oContact.SetExtendedProperty(oInternalContactId, <<INSERT INTEGER OF ID HERE>>)
    oContact.Save()
