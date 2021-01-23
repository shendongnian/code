    Imports System.Data.OleDb
    
    Public Class SwitchTableOnBindingSourceForm
        WithEvents bsData As New BindingSource
        Private Sub SwitchTableOnBindingSourceForm_Load(
            sender As Object, e As EventArgs) Handles MyBase.Load
    
            cboTables.DataSource = SchemaInfo.GetInstance.TableNames(
                IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "NorthWind.accdb"))
    
            DataGridView1.DataSource = bsData
    
        End Sub
        Private Sub cmdSelectTable_Click(
            sender As Object, e As EventArgs) Handles cmdSelectTable.Click
    
            Dim dt As New DataTable
            Using cn As New OleDbConnection(SchemaInfo.GetInstance.ConnectionString)
                Using cmd As New OleDbCommand("SELECT * FROM " & cboTables.Text, cn)
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                End Using
            End Using
    
            bsData.DataSource = dt
    
        End Sub
    End Class
