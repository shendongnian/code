    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
            If (ComboBox1.SelectedIndex = 3) Then            
                Select3()    
            End If
        End Sub
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load    
            Dim range() As String = {"0", "1", "2", "3 - Fire Combo2", "4", "5", "6"}
            ComboBox1.Items.AddRange(range)            
        End Sub
    
        Private Sub Select3()
            Dim connectionString As String = MyStandAloneDB.DBConnStr
            Dim conn As New System.Data.SQLite.SQLiteConnection(connectionString)
            conn.Open()
            Dim cmd1 As New System.Data.SQLite.SQLiteCommand
            cmd1.Connection = conn
            cmd1.CommandType = CommandType.Text
            cmd1.CommandText = "SELECT * FROM Foo"
            Dim dt1 As New DataTable()
            Dim adp1 As New System.Data.SQLite.SQLiteDataAdapter(cmd1)
            adp1.Fill(dt1)
            ComboBox2.DataSource = dt1
            ComboBox2.ValueMember = dt1.Columns(1).ToString
            ComboBox2.DisplayMember = dt1.Columns(0).ToString
        End Sub
