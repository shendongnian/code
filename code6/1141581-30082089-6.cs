        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if(newStudent == null) MessageBox.Show("Students collection is null.");
            foreach (Student i in newStudent)
            {
                MessageBox.Show(string.Format("First name: {0} Last name: {1}", i.firstName, i.lastName));
            }
            //MessageBox.Show(student.AllStudentsList[0].ToString());
        }
