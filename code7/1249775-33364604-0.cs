         string ConnectionString;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ConnectionString = ConfigurationManager.ConnectionStrings["ConHprENWL"].ConnectionString
                    break;
                case 1:
                    ConnectionString = ConfigurationManager.ConnectionStrings["XYZ"].ConnectionString
                    break;
                
            }
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();  
    /*YOUR CODE */
