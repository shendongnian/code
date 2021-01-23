    private void CheckContactNumber()
        {
            string checkContactNum = "SELECT COUNT(*) FROM Employee WHERE ContactNumber = " + addContactNum.Text + " "; //01234567890
            OleDbCommand cmd = new OleDbCommand(checkContactNum, conn);
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            //if (dr.Read() && addContactNum.Text != "")
            if (dr.Read())
            {
                int count = (int)dr[0];
                if(count>0)
                {
                    err += "Contact number is already listed in the database\r\n";
                    errorContactNum.Visible = true;
                    uniqueContactNumber = false;
                }
                
            }
            conn.Close();
        }
