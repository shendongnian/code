    Public dtArticles As DataTable
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
        dtArticles = GetData()
    
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
