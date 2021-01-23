    try{
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O72COGQ;Initial Catalog=ClinicManagementtest;Integrated Security=True"))
        {
            con.Open();
            using (SqlCommand sc = new SqlCommand("INSERT INTO  Patient_Details VALUES(@Id, @Name, @Age, @ContactNo, @Address)", con)){
                sc.Parameters.AddWithValue("@Id", textBox1.Text);
                sc.Parameters.AddWithValue("@Name", textBox2.Text);
                sc.Parameters.AddWithValue("@ContactNo", textBox3.Text);
                sc.Parameters.AddWithValue("@Age", textBox4.Text);
                sc.Parameters.AddWithValue("@Address", textBox5.Text);
                int o = sc.ExecuteNonQuery();
                MessageBox.Show(o + ":Record has been inserted");
            }
        }
    }catch(Exception ex){
         MessageBox.Show(ex.Message);
    }
