    Imports System.Data.SqlClient
    
    Public Class Form1
    
        Private connection As New SqlConnection("connection string here")
        Private adapter As New SqlDataAdapter("SELECT * FROM Person", connection)
        Private builder As New SqlCommandBuilder(adapter)
        Private table As New DataTable
    
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            adapter.Fill(table)
            BindingSource1.DataSource = table
            DataGridView1.DataSource = BindingSource1
            givenNameTextBox.DataBindings.Add("Text", BindingSource1, "GivenName")
            familyNameTextBox.DataBindings.Add("Text", BindingSource1, "FamilyName")
        End Sub
    
        Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
            BindingSource1.AddNew()
        End Sub
    
        Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click
            BindingSource1.RemoveCurrent()
        End Sub
    
        Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
            BindingSource1.EndEdit()
            adapter.Update(table)
        End Sub
    
    End Class
