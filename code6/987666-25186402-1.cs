        Public Overrides Function Clone() As Object
            Dim Copy As DGVColumn = DirectCast(MyBase.Clone, DGVColumn)
            Copy._headerCell = DirectCast(_headerCell.Clone, DataGridViewColumnHeaderCell)
            Copy.HeaderCell = Copy._HeaderCell
            Return Copy
        End Function
