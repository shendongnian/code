    Private Sub UpdateCellValue(Of T)(columnName As String, value As T)
        If dgvBayList.SelectedRows.Count > 0 Then
            Dim crow As DataGridViewRow = dgvBayList.SelectedRows(0)
            Dim drv As DataRowView = DirectCast(bsDataSource.Current, DataRowView)
            If crow.Cells(columnName).Value = value Then
                Exit Sub
            End If
            drv.BeginEdit()
            drv.Row.BeginEdit()
            drv.Row.SetField(Of T)(columnName, value)
            crow.Cells(columnName).Value = value
            Dim objType As Type = drv.Row(columnName).GetType()
            Dim method As Reflection.MethodInfo = Me.GetType().GetMethod("SetDataGridViewCellStyle", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Public)
            Dim GenericSetDataGridViewCellStyle As Reflection.MethodInfo = method.MakeGenericMethod(objType)
            Dim parms As Object() = {crow.Cells(columnName), drv, columnName}
            GenericSetDataGridViewCellStyle.Invoke(Me, parms)
            drv.Row.EndEdit()
            drv.EndEdit()
        End If
    End Sub
    Private Sub SetDataGridViewCellStyle(Of T)(cell As DataGridViewCell, dRowView As DataRowView, columnName As String)
        Dim nothingness As Integer = 0
        If dRowView.Row.Field(Of T)(columnName, DataRowVersion.Original) Is Nothing Then
            nothingness += 1
        End If
        If dRowView.Row.Field(Of T)(columnName, DataRowVersion.Current) Is Nothing Then
            nothingness += 1
        End If
        If nothingness = 0 Then
            Dim original As T = dRowView.Row.Field(Of T)(columnName, DataRowVersion.Original)
            Dim current As T = dRowView.Row.Field(Of T)(columnName, DataRowVersion.Current)
            Dim proposed As T = dRowView.Row.Field(Of T)(columnName, DataRowVersion.Proposed)
            If EqualsCompare(Of T)(original, proposed) Then   
                cell.Style.BackColor = Color.FromKnownColor(KnownColor.White)
            Else
                cell.Style.BackColor = Color.FromKnownColor(KnownColor.Fuchsia)
            End If
        Else
            If nothingness = 2 Then
                cell.Style.BackColor = Color.FromKnownColor(KnownColor.White)
            Else
                ' cell.Style.BackColor = Color.FromKnownColor(KnownColor.Fuchsia)'
            End If
        End If
        cell.DataGridView.Update()
    End Sub
    Public Shared Function EqualsCompare(Of T)(a As T, b As T) As Boolean
        Return EqualityComparer(Of T).[Default].Equals(a, b)
    End Function
