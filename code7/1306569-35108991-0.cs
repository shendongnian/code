    Dim settings As New RequestSettings("MyApp", RefreshOAuthToken())
    Dim cr As New ContactsRequest(settings)
        'retrieve Contacts group (this is to retrieve only real contacts)
    Dim groupquery As New GroupsQuery(GroupsQuery.CreateGroupsUri("default"))
    Dim fgrp As Feed(Of Group) = cr.Get(Of Group)(groupquery)
    Dim GroupAtomId As String = ""
    For Each gr In fgrp.Entries
        If gr.Title.Contains("Contacts") Then
           GroupAtomId = gr.Id
                 Exit For
        End If
    Next
