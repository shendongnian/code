        Private Sub GridView1_CustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEditForEditing
            If (e.Column.FieldName = "NewLawyers") Then
                riCombo.Items.Clear()
                riCombo.Items.AddRange(allLawyersNames)
                e.RepositoryItem = riCombo
            End If
        End Sub
