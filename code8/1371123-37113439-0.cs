            if (!(string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txthotel.Text))) 
            {
                ///register client
                connect.Open();
                MySqlCommand command = new MySqlCommand("Insert into client (firstName,lastName,Nationality,mobile,email,budget,comments) value(@firstName,@lastName,@Nationality,@mobile,@email,@budget,@comments)", connect);
                command.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                command.Parameters.AddWithValue("@lastName", txtLastName.Text);
                command.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                command.Parameters.AddWithValue("@mobile", txtMobile.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@budget", int.Parse(txtBudget.Text));
                command.Parameters.AddWithValue("@comments", txtComments.Text);
                command.ExecuteNonQuery();
                connect.Close();
                loadclient();
                ///register appointment
                connect.Open();
                command = new MySqlCommand("Insert into appointment(Hotel,Roomnumber,AppointmentDate,Appointmenttime,ConfirmBy,Propertytype,Bedrooms,Purpose,Interestedin,Departuredate) value(@Hotel,@Roomnumber,@AppointmentDate,@Appointmenttime,@ConfirmBy,@Propertytype,@Bedrooms,@Purpose,@Interestedin,@Departuredate)", connect);
                command.Parameters.AddWithValue("@Hotel", txthotel.Text);
                command.Parameters.AddWithValue("@Roomnumber", int.Parse(txtRoomNumber.Text));
                command.Parameters.AddWithValue("@AppointmentDate", dateTimePicker2.Value.Date);
                command.Parameters.AddWithValue("@Appointmenttime", cmbTimeApp.Text);
                command.Parameters.AddWithValue("@ConfirmBy", cmbConfirm.Text);
                command.Parameters.AddWithValue("@Propertytype", cmbpropertytype.Text);
                command.Parameters.AddWithValue("@Bedrooms", cmbBedRoom.Text);
                command.Parameters.AddWithValue("@Purpose", cmbPurpose.Text);
                command.Parameters.AddWithValue("@Interestedin", cmbIntrestedIn.Text);
                command.Parameters.AddWithValue("@Departuredate", dateTimePicker3.Value.Date);
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Appointment registered!");
            }
