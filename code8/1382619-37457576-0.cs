    //String points = null;
    int points = 0;
    
    String ServiceCarWash = "Not Booked";
    String ServiceCarPolish = "Not Booked";
    String ServiceCarWax = "Not Booked";
    int CustomerID = 0;
    
    private void btnBook_Click_1(object sender, EventArgs e)
    {
        try
        {
    
            connection.Open();
            String query = "INSERT into Booking ([Time],[Date],[CID],[VehicleNumber],[CarWash],[CarPolish],[CarWax])  VALUES('" + cmbTime.Text + "','" + dateTimePicker1.Text + "','" + CustomerID + "','" + txtVn.Text + "','" + ServiceCarWash + "','" + ServiceCarPolish + "','" + ServiceCarWax + "')";
            OleDbCommand command = new OleDbCommand(query);
            command.Connection = connection;
            command.ExecuteNonQuery();
    
            if (CbCarwash.Checked)
            {
                ServiceCarWash = "Booked";
            }
    
            if (CbCarPolish.Checked)
            {
                ServiceCarPolish = "Booked";
            }
    
            if (CbCarWax.Checked)
            {
                ServiceCarWax = "Booked";
            }
    
            {
                if (txtMember.Text.Equals("VIP"))
                {
                    if (ServiceCarPolish == "Booked")
                    {
                        points += 20;
                    }
                    if (ServiceCarWash == "Booked")
                    {
                        points += 2;
                    }
                    if (ServiceCarWax == "Booked")
                    {
                        points += 8;
                    }
                }
                else if (txtMember.Text.Equals("Walk-In"))
                {
    
                    if (ServiceCarPolish == "Booked")
                    {
                        points += 0;
                    }
                    if (ServiceCarWash == "Booked")
                    {
                        points += 0;
                    }
                    if (ServiceCarWax == "Booked")
                    {
                        points += 0;
                    }
                }
    
     //string query1 = "UPDATE *Customer set Points='" + points + "'";
                string query1 = "UPDATE *Customer set Points='" + points.ToString() + "'";
                OleDbCommand command1 = new OleDbCommand(query1);
                command1.Connection = connection;
                command1.ExecuteNonQuery();
                MessageBox.Show("Your time has been booked.");
    
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error" + ex);
        }
    }
