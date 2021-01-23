    Public Class AddLesseeForm 'Form2
        
        	'This is the Select Button
            Public Sub Button4_SelectLessee_Click(sender As Object, e As EventArgs) Handles Button4_SelectLessee.Click
        	
        		AddData.loadLessee(TextBox1_LesseeID.Text, TextBox2_LesseeName.Text)
        		
            End Sub
        End Class
