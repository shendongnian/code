    Public Class Form1
        Public Sub New()
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US")
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US")
            Me.InitializeComponent()
            Me.ClientSize = New Size(350, 400)
            Me.column1 = New DataGridViewTextBoxColumn With {.Name = "Column1", .HeaderText = "Double (F2)", .ValueType = GetType(Double), .Width = 100}
            Me.column1.DefaultCellStyle.Format = "F2"
            Me.column2 = New DataGridViewTextBoxColumn With {.Name = "Column2", .HeaderText = "Double (F8)", .ValueType = GetType(Double), .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .MinimumWidth = 100}
            Me.column2.DefaultCellStyle.Format = "F8"
            Me.grid = New DataGridView With {.Dock = DockStyle.Fill}
            Me.grid.Columns.AddRange(Me.column1, Me.column2)
            For i As Double = 0.0R To 9.0R : Me.grid.Rows.Add(i, i) : Next
            Me.Controls.Add(Me.grid)
        End Sub
        Private WithEvents grid As DataGridView
        Private WithEvents column1 As DataGridViewTextBoxColumn
        Private WithEvents column2 As DataGridViewTextBoxColumn
    End Class
