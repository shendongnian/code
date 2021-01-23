    Public Property dtArticles As DataTable
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    
        dtArticles = GetData()
    
        For I As Integer = 0 To dtArticles.Rows.Count - 1
            Dim row As DataRow = dtArticles.Rows(I)
            Dim label As Label = Page.FindControl(String.Format("Name{0}", I))
            label.Text = String.Format("{0} ({1})", row("Name"), row("Value"))
        Next
    
    End Sub
    Private Function GetData() As DataTable
        Dim conn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString)
        Dim cmd As New SqlCommand("usp_MyProc", conn)
        Dim da As New SqlDataAdapter()
        da.SelectCommand = cmd
        Dim dt As New Data.DataTable()
        da.Fill(dt)
        Return dt
    End Function
