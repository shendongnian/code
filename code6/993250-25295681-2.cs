        Public Shared Sub ToggleButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    
        Dim senderButton As Primitives.ToggleButton
        senderButton = CType(sender, Primitives.ToggleButton)
        Dim clickedRow As DataGridRow = CType(GetVisualParent(senderButton, GetType(DataGridRow)), DataGridRow)
    
        If clickedRow IsNot Nothing Then
            If senderButton.IsChecked Then
                clickedRow.DetailsVisibility = Windows.Visibility.Visible
                clickedRow.BringIntoView()
            Else
                clickedRow.DetailsVisibility = Windows.Visibility.Collapsed
            End If
        End If
      End Sub
