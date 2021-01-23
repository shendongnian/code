    Sub RemoveAllAndAddColumns()
    'Declarations
    Dim Filter As String
    Dim oRow As Outlook.Row
    Dim oTable As Outlook.Table
    Dim oFolder As Outlook.Folder
    'Get a Folder object for the Inbox
    Set oFolder = Application.Session.GetDefaultFolder(olFolderInbox)
    'Define Filter to obtain items last modified after May 1, 2005
    Filter = "[LastModificationTime] > '5/1/2005'"
    'Restrict with Filter
    Set oTable = oFolder.GetTable(Filter)
    'Remove all columns in the default column set
    oTable.Columns.RemoveAll
    'Specify desired properties
    With oTable.Columns
        .Add ("Subject")
        .Add ("LastModificationTime")
        'PR_ATTR_HIDDEN referenced by the MAPI proptag namespace
        .Add ("http://schemas.microsoft.com/mapi/proptag/0x10F4000B")
    End With
    'Enumerate the table using test for EndOfTable
    Do Until (oTable.EndOfTable)
        Set oRow = oTable.GetNextRow()
        Debug.Print (oRow("Subject"))
        Debug.Print (oRow("LastModificationTime"))
        Debug.Print (oRow("http://schemas.microsoft.com/mapi/proptag/0x10F4000B"))
    Loop
    End Sub
