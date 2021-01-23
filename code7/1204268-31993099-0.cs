    public void searchPersId(string persId)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand myCommand = new SqlCommand("SELECT persName FROM Customers  WHERE persId = @persId", conn);
            myCommand.Parameters.AddWithValue("@persId", persId);
            object personName = myCommand.ExecuteScalar();
            if(!string.IsNullOrEmpty(personName.ToString()))
            //if (textBox1.Text = myCommand) //I dont know how to compare the values of textbox with myCommand..
            {
                //Show values (persId and persName) in two textBoxes in a new form. 
                textBox2.Text = personName.ToString();
            }
            else
            {
                MessageBox.Show("The ID does not exist.");
            }
        }
