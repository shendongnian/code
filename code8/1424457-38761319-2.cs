    try{
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O72COGQ;Initial Catalog=ClinicManagementtest;Integrated Security=True"))
        {
            con.Open();
            using (SqlCommand sc = new SqlCommand("INSERT INTO  Patient_Details VALUES(@Id, @Name, @Age,@Gender, @ContactNo, @Address)", con)){
                sc.Parameters.AddWithValue("@Id", textBox1.Text);
                sc.Parameters.AddWithValue("@Name", textBox2.Text);
                sc.Parameters.AddWithValue("@Gender", textBox3.Text);
                sc.Parameters.AddWithValue("@ContactNo", textBox4.Text);
                sc.Parameters.AddWithValue("@Age", textBox5.Text);
                sc.Parameters.AddWithValue("@Address", textBox6.Text);
                int o = sc.ExecuteNonQuery();
                MessageBox.Show(o + ":Record has been inserted");
            }
        }
    }catch(Exception ex){
         MessageBox.Show(ex.Message);
    }
