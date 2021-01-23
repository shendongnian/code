     protected void SaveScore_Click(object sender, EventArgs e)
        {
                Grades studentGrade = new Grades();
                studentGrade.enrollmentId = DDStudents.SelectedItem.Value;
                //studentGrade.calculate();
                AssignmentError.Text = studentGrade.enrollmentId;               
        }
