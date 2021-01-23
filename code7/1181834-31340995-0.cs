    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        //Insert 3 rows
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()
        DataGridView1.Rows.Add()
        //set ReadOnly = False
        DataGridView1.ReadOnly = False
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim cell As DataGridViewComboBoxCell = DataGridView1.Rows(i).Cells("Poles")
            //insert values 1,2,3 in first row and set selected value of combobox
            If i = 0 Then
                DataGridView1.Rows(i).Cells(0).Value = "Employ1"
                cell.Items.Add("1")
                cell.Items.Add("2")
                cell.Items.Add("3")
                cell.Value = cell.Items(0)
            End If
            //insert values 4,5,6 in first row and set selected value of combobox
            If i = 1 Then
                DataGridView1.Rows(i).Cells(0).Value = "Employ2"
                cell.Items.Add("4")
                cell.Items.Add("5")
                cell.Items.Add("6")
                cell.Value = cell.Items(0)
            End If
            //insert values 7,8,9 in first row and set selected value of combobox
            If i = 2 Then
                DataGridView1.Rows(i).Cells(0).Value = "Employ3"
                cell.Items.Add("7")
                cell.Items.Add("8")
                cell.Items.Add("9")
                cell.Value = cell.Items(0)
            End If
        Next i
    End Sub
