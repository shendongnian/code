       protected void Button1_Click(object sender, EventArgs e)
        {
            if (dropdownrole.SelectedItem.Text == "Admin")
            {
                Admin();
            }
            else if (dropdownrole.SelectedItem.Text == "Student")
            {
                Student();
            }
            else if (dropdownrole.SelectedItem.Text == "Teacher")
            {
                Teacher();
            }
        }
