    Private Shared ListOfNames As BindingList(Of Names) = New BindingList(Of Names)
    Private Delegate Sub AddNameToListDelegate(newName As Names)
    Public Sub InvokeANDCreateHandle(ByVal newNames As Names)
        Try
            If Me.IsHandleCreated = False Then
                Me.CreateHandle()
            End If
            DataGridView1.Invoke(New AddNameToListDelegate(AddressOf AddNameToList), newNames)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub AddNameToList(name As Names)
        ListOfNames.Add(name)
    End Sub
