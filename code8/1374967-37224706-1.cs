    Public Class AddData 'Form1
    
        Private Sub Button1_AddLesseeForm_Click(sender As Object, e As EventArgs) Handles Button1_AddLesseeForm.Click
            AddLesseeForm.Show()
    
        End Sub
    
    	Public Sub loadLessee(LesseeId As String, LesseeName As String)
    
            TextBox1_LesseeId.Text = LesseeId
            TextBox2_LesseeNm.Text = LesseeName
    
        End Sub
    
        Public Sub AddData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
           
        End Sub
    End Class
