    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load
    
    [...]
        
    Using Conn = New SqlConnection(ConnString)
                dt = New DataTable
                Dim da As New SqlDataAdapter("SELECT DateName(M,'1900-' + CONVERT(VARCHAR, X.iMonth) + '-01') sMonth, X.iMonth " & _
                                             " FROM (SELECT TOP 12 ROW_NUMBER() OVER(ORDER BY name) iMonth from sys.objects) X", Conn)
                da.Fill(dt)
            End Using
    
            For Each dr As DataGridViewRow In DataGridView1.Rows
                Dim ComboCell As New DataGridViewComboBoxCell
    
                DataGridView1("sNotes", dr.Index) = ComboCell
                ComboCell.DataSource = dt
                ComboCell.DisplayMember = "sMonth"
                ComboCell.ValueMember = "iMonth"
            Next
    
    [...]
    
    End Sub
