    Private Function GetAllSyncedContactIdsInExchange(pService As ExchangeService) As List(Of Integer)
        Dim oInternalContactIdDefinition As New ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, conContactIdPropertyName, MapiPropertyType.Integer)
        Dim oInternalContactIdFilter As New SearchFilter.Exists(oInternalContactIdDefinition)
        Dim oResults As FindItemsResults(Of Item) = Nothing
        Dim oPropertySet As New PropertySet(oInternalContactIdDefinition)
        Dim lstSyncedContactIds As New List(Of Integer)
        Dim intDBId As Integer
        Dim lstEESContactFolders As List(Of FolderId) = GetAllCustomEESFolderIds(pService)
        For Each oFolderId As FolderId In lstEESContactFolders
            Dim blnMoreAvailable As Boolean = True
            Dim intSearchOffset As Integer = 0
            Dim oView As New ItemView(conMaxChangesReturned, intSearchOffset, OffsetBasePoint.Beginning)
            oView.PropertySet = BasePropertySet.IdOnly
            Do While blnMoreAvailable
                oResults = pService.FindItems(oFolderId, oInternalContactIdFilter, oView)
                blnMoreAvailable = oResults.MoreAvailable
                If Not IsNothing(oResults) AndAlso oResults.Items.Count > 0 Then
                    pService.LoadPropertiesForItems(oResults, oPropertySet)
                    For Each oExchangeItem As Item In oResults.Items
                        If oExchangeItem.TryGetProperty(oInternalContactIdDefinition, intDB2Id) Then
                            lstSyncedContactIds.Add(intDBId)
                        End If
                    Next
                    If blnMoreAvailable Then oView.Offset = oView.Offset + conMaxChangesReturned
                End If
            Loop
        Next
        Return lstSyncedContactIds
    End Function
