    Imports System.Globalization
    Public Class Form1
        ''' <summary>
        ''' One column added in the designer
        ''' Form load I add a ComboBox with weekday names for data source
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
            DataGridView1.Columns.Add(
                New DataGridViewComboBoxColumn With
                {
                    .DataSource = CultureInfo.CurrentCulture.DateTimeFormat.DayNames,
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                    .Name = "DayColumn",
                    .HeaderText = "Week day",
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                }
            )
    
            DataGridView1.Rows.Add(New Object() {"AAA", "Friday"})
            DataGridView1.Rows.Add(New Object() {"BBB"})
            DataGridView1.Rows.Add(New Object() {"CCC", "Monday"})
            DataGridView1.Rows.Add(New Object() {"DDD", "XYZ"})
        End Sub
    
        Private Sub DataGridView1_DataError(
            sender As Object,
            e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
    
            If e.Exception.Message = "DataGridViewComboBoxCell value is not valid." Then
                Console.WriteLine("Not valid week name [{0}]", DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                e.Cancel = True
            End If
    
        End Sub
    End Class
 
