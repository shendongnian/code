    Imports System.Data.OleDb
    Public Class SchemaInfo
        Private Shared _Instance As SchemaInfo
        Public Shared Function GetInstance() As SchemaInfo
            If _Instance Is Nothing Then
                _Instance = New SchemaInfo
            End If
            Return _Instance
        End Function
        Protected Sub New()
        End Sub
        Private Shared _ConnectionString As String
        Public Function ConnectionString() As String
            Return _ConnectionString
        End Function
        Public Function TableNames(ByVal DatabaseName As String) As List(Of String)
            Dim Names As New List(Of String)
    
            Using cn As New OleDbConnection(BuildConnectionString(DatabaseName))
                _ConnectionString = cn.ConnectionString
                cn.Open()
    
                Dim dt As DataTable = cn.GetSchema("Tables", New String() {Nothing, Nothing, Nothing, "Table"})
    
                For Each row As DataRow In dt.Rows
                    Names.Add(row.Field(Of String)("Table_Name"))
                Next
    
            End Using
    
            Return Names
    
        End Function
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Shared Function BuildConnectionString(ByVal DatabaseName As String) As String
    
            If IO.Path.GetExtension(DatabaseName).ToLower = ".accdb" Then
    
                Dim Builder As New OleDb.OleDbConnectionStringBuilder With
                    {
                        .Provider = "Microsoft.ACE.OLEDB.12.0",
                        .DataSource = DatabaseName
                    }
    
                Return Builder.ConnectionString
    
            ElseIf IO.Path.GetExtension(DatabaseName).ToLower = ".mdb" Then
    
                Dim Builder As New OleDb.OleDbConnectionStringBuilder With
                    {
                        .Provider = "Microsoft.Jet.OLEDB.4.0",
                        .DataSource = DatabaseName
                    }
    
                Return Builder.ConnectionString
    
            Else
    
                Throw New Exception("File type not supported")
    
            End If
    
        End Function
    End Class
