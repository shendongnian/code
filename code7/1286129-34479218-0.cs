    Dim columnCount As Integer = 4
    Dim rowCount As Integer = 13
    Me.TableLayoutPanel1.ColumnCount = columnCount
    Me.TableLayoutPanel1.RowCount = rowCount
    Me.TableLayoutPanel1.ColumnStyles.Clear()
    Me.TableLayoutPanel1.RowStyles.Clear()
    Me.TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    Me.TableLayoutPanel1.BackColor = Color.White
    For i = 0 To columnCount - 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount))
    Next
    For i = 0 To rowCount - 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount))
    Next
    Me.SuspendLayout()
    For i = 1 To 50
        Dim label As New Label
        label.Text = i
        label.Font = New Font(label.Font, FontStyle.Bold)
        label.AutoSize = False
        label.Size = New Size(30, 30)
        label.Image = My.Resources.Circle
        label.ImageAlign = ContentAlignment.MiddleCenter
        label.TextAlign = ContentAlignment.MiddleCenter
        label.Dock = DockStyle.Fill
        Me.TableLayoutPanel1.Controls.Add(label)
    Next
    Me.ResumeLayout()
