    using (SqlConnection connection = new SqlConnection(/* connection info */))
    {
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
       		 command.Parameters.AddWithValue("@ID",textBox1.Text);
        	command.Parameters.AddWithValue("@stdname",textbox2.Text);
        	command.Parameters.AddWithValue("@fathername",textBox3.Text);
        	command.Parameters.AddWithValue("@program",textBox4.Text);
        	command.Parameters.AddWithValue("@adress",textBox5.Text);
        	command.Parameters.AddWithValue("@email",textBox6.Text);
        	command.Parameters.AddWithValue("cellNum",textBox7.Text);
        	command.Parameters.AddWithValue("@isPaid",textBox8.Text);
        	command.Parameters.AddWithValue("@SubmissionDate",dateTimePicker1.Value.ToString("MM/dd/yyyy"));
        	connection.Open();
            var results = command.ExecuteReader();
        }
    }
