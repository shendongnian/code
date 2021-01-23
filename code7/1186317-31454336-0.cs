    Public Class DataGridViewImageComboBox
        Inherits DataGridViewComboBoxColumn
    
        Public Sub New()
            MyBase.New()
            CellTemplate = New DataGridViewImageComboBoxCell()
        End Sub
    
    End Class
    
    Public Class DataGridViewImageComboBoxCell
        Inherits DataGridViewComboBoxCell
    
        Protected Overrides Sub Paint(graphics As Graphics,
                                      clipBounds As Rectangle,
                                      cellBounds As Rectangle,
                                      rowIndex As Integer,
                                      elementState As DataGridViewElementStates,
                                      value As Object,
                                      formattedValue As Object,
                                      errorText As String,
                                      cellStyle As DataGridViewCellStyle,
                                      advancedBorderStyle As DataGridViewAdvancedBorderStyle,
                                      paintParts As DataGridViewPaintParts)
            MyBase.Paint(...)  'only if in need of original paint
            'do custom painting here
    
        End Sub
    
    End Class
