       private void btnSubmit_Click(object sender, EventArgs e)
        {
            // split the name into first and last name
            string[] name = txtName.Text.Split(',');
            Data std = new Data();
            std.FirstName = name[0];
            std.LastName = name[1];
            std.Exam1 = Int32.Parse(txtExam1.Text);
            std.Exam2= Int32.Parse(txtExam2.Text);
            std.Exam3 = Int32.Parse(txtExam3.Text);
            std.FinalExam = Int32.Parse(txtFinal.Text);
            stu.addItem(std);
            this.Hide();
        }
