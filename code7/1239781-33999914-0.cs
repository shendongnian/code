        Private Sub CustomDataGrid_AutoGeneratingColumn(sender As Object, e As DataGridAutoGeneratingColumnEventArgs) Handles Me.AutoGeneratingColumn
            e.Cancel = True
            Dim binding As New Binding
            Dim textColumn = TryCast(e.Column, DataGridTextColumn)
            If textColumn IsNot Nothing Then
                binding = textColumn.Binding
                binding.TargetNullValue = "-"
            End If
            Columns.Add(New CustomColumn() With {.Header = e.Column.Header, .Binding = binding})
        End Sub
...
    Public Class CustomColumn
    Protected Overrides Function GenerateElement(cell As DataGridCell, dataItem As Object) As FrameworkElement
        Dim block As New TextBlock()
        Dim column As CustomColumn = DirectCast(cell.Column, CustomColumn)
        Dim binding As Binding = DirectCast(column.Binding, Binding)
        If binding IsNot Nothing Then
            Dim cellBinding As New Binding(binding.Path.Path)
            cellBinding.Source = dataItem
            cellBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            cellBinding.ValidatesOnDataErrors = True
            cellBinding.ValidatesOnExceptions = True
            cellBinding.NotifyOnValidationError = True
            cellBinding.ValidatesOnNotifyDataErrors = True
            cellBinding.Mode = BindingMode.OneWay
            block.SetBinding(TextBlock.TextProperty, cellBinding)
            block.TextTrimming = TextTrimming.CharacterEllipsis
        End If
        Return block
    End Function
    End Class
    
