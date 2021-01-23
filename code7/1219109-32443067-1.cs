    var user = new User();
    
    user.Id = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
    user.Username = (string) dataGridView1.SelectedRows[0].Cells[1].Value;
    user.FirstName = (string) dataGridView1.SelectedRows[0].Cells[2].Value;
    user.LastName = (string) dataGridView1.SelectedRows[0].Cells[3].Value;
    user.Email = (string) dataGridView1.SelectedRows[0].Cells[4].Value;
    user.Password = (string) dataGridView1.SelectedRows[0].Cells[5].Value;
    SecondObject obj = new SecondObject(user);
